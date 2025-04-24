using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Lab3.Server.Models;

namespace Lab3.NoPattern.Client;

public class UserService
{
    public event Action<ChatContent>? OnMessageReceived;
    
    private readonly User _user;
    private readonly UdpClient _updClient;
    private readonly Thread _receiveThread;
    private bool _isRunning;

    public UserService(User user, UdpClient updClient)
    {
        _user = user;
        _updClient = updClient;
        _receiveThread = new Thread(ReceiveMessages);
        
        _receiveThread.Start();
    }
    
    private void ReceiveMessages()
    {
        while (_isRunning)
            try
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                var data = _updClient.Receive(ref remoteEndPoint);
                var json = Encoding.UTF8.GetString(data);
                var message = JsonSerializer.Deserialize<ChatContent>(json);
                
                if(message.SenderName == _user.Username)
                    continue;

                if (message.MessageType == MessageTypes.Ack)
                    continue;

                if (message.RequiresAck)
                    SendContentOnServer(new ChatContent
                    {
                        MessageType = MessageTypes.Ack,
                        MessageId = message.MessageId,
                        SenderName = _user.Username,
                    });

                OnMessageReceived?.Invoke(message);
            }
            catch (SocketException)
            {
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении сообщения: {ex.Message}");
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
        _updClient.Send(data, data.Length);
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

    private void Dispose()
    {
        _isRunning = false;
        _updClient.Close();

        // Ждем завершения потоков
        if (_receiveThread.IsAlive) _receiveThread.Join();
    }
}