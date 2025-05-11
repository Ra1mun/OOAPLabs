using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Lab3.Server.Models;
using Lab3.Server.Server;

namespace Lab4.NoPattern.Client;

public interface IChatMediator
{ 
    Action<ChatContent>? MessageReceived { get; set; }
    void Connect();
    void SendMessage(string content);
    void SendMessage(string content, User sender);
    void Disconnect();
}

public class ChatMediator : IDisposable, IChatMediator
{
    public Action<ChatContent>? MessageReceived { get; set; }

    private readonly UdpClient _client = new();
    private readonly User _user;
    
    private readonly Thread _isAliveThread;
    private readonly Thread _receiveThread;
    
    private bool _isRunning;

    public ChatMediator(User user)
    {
        _user = user;
        
        _receiveThread = new Thread(ReceiveMessages);
        _isAliveThread = new Thread(SendIsAlive);
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
        _isAliveThread.Start();
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

                if (message.SenderName == _user.Username)
                    return;

                if (message.MessageType == MessageTypes.Ack)
                    continue;

                if (message.RequiresAck)
                    SendContentOnServer(new ChatContent
                    {
                        MessageType = MessageTypes.Ack,
                        MessageId = message.MessageId,
                        SenderName = _user.Username,
                    });

                MessageReceived?.Invoke(message);
            }
            catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
            {
                MessageBox.Show("Сервер не ответил за отведённое время.");
                break;
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Ошибка при подключении к серверу: {ex.Message}");
                break;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении сообщения: {ex.Message}");
            }
    }

    private void SendIsAlive()
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
        SendMessage(content, _user);
    }

    public void SendMessage(string content, User sender)
    {
        var message = new ChatContent
        {
            MessageType = MessageTypes.ChatMessage,
            SenderName = sender.Username,
            Content = content,
            IsPremium = sender.Premium,
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
        if (_isAliveThread.IsAlive) _isAliveThread.Join();
    }
}