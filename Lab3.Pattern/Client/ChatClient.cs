using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Lab3.Server.Models;
using Lab3.Server.Server;

namespace Lab3.Pattern.Client;

public interface IChatMediator
{ 
    Action<ChatContent>? MessageReceived { get; set; }
    
    void SendMessage(string content);
    void Disconnect();
}

public class ChatClient : IDisposable, IChatMediator
{
    public Action<ChatContent>? MessageReceived { get; set; }

    private readonly UdpClient _client = new();
    private readonly User _user;
    
    private readonly Thread _heartbeatThread;
    private readonly Thread _receiveThread;
    
    private bool _isRunning;

    public ChatClient(User user)
    {
        _user = user;

        _receiveThread = new Thread(ReceiveMessages);
        _heartbeatThread = new Thread(SendHeartbeat);
    }

    public void Connect()
    {
        var serverEndPoint = new IPEndPoint(IPAddress.Parse(ServerSettings.IP_ADDRESS), ServerSettings.PORT);
        
        _client.Connect(serverEndPoint);

        SendContentOnServer(new ChatContent
        {
            MessageType = MessageTypes.UserJoined,
            SenderName = _user.Username,
            IsPremium = _user.Premium,
            Timestamp = DateTime.Now,
            RequiresAck = true
        });

        _isRunning = true;
        _receiveThread.Start();
        _heartbeatThread.Start();
    }

    private void ReceiveMessages()
    {
        while (_isRunning)
            try
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                var data = _client.Receive(ref remoteEndPoint);
                var json = Encoding.UTF8.GetString(data);
                var message = JsonSerializer.Deserialize<ChatContent>(json);

                if (message.MessageType == MessageTypes.Ack)
                    continue;

                // Отправляем подтверждение получения для сообщений, требующих этого
                if (message.RequiresAck)
                    SendContentOnServer(new ChatContent
                    {
                        MessageType = MessageTypes.Ack,
                        MessageId = message.MessageId,
                        SenderName = _user.Username,
                    });

                MessageReceived?.Invoke(message);
            }
            catch (SocketException)
            {
                // Игнорируем ошибки сокета при закрытии
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении сообщения: {ex.Message}");
            }
    }

    private void SendHeartbeat()
    {
        while (_isRunning)
            try
            {
                SendContentOnServer(new ChatContent
                {
                    MessageType = MessageTypes.IsAlive,
                    SenderName = _user.Username,
                    Timestamp = DateTime.Now
                });

                Thread.Sleep(3000); // Отправляем heartbeat каждые 3 секунды
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка отправки heartbeat: {ex.Message}");
            }
    }

    public void SendMessage(string content)
    {
        var message = new ChatContent
        {
            MessageType = MessageTypes.ChatMessage,
            SenderName = _user.Username,
            Content = content,
            IsPremium = _user.Premium,
            Timestamp = DateTime.Now,
            RequiresAck = true
        };

        SendContentOnServer(message);
    }

    private void SendContentOnServer(ChatContent content)
    {
        var json = JsonSerializer.Serialize(content);
        var data = Encoding.UTF8.GetBytes(json);
        _client.Send(data, data.Length);
    }

    public void Disconnect()
    {
        if (!_isRunning) return;

        try
        {
            SendContentOnServer(new ChatContent
            {
                MessageType = MessageTypes.UserLeft,
                SenderName = _user.Username,
                Timestamp = DateTime.Now,
                RequiresAck = true
            });
        }
        finally
        {
            Dispose();
        }
    }
    
    public void Dispose()
    {
        _isRunning = false;
        _client.Close();

        // Ждем завершения потоков
        if (_receiveThread.IsAlive) _receiveThread.Join();
        if (_heartbeatThread.IsAlive) _heartbeatThread.Join();
    }
}