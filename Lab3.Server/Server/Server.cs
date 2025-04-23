using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Lab3.Server.Models;

namespace Lab3.Server.Server;

public class ChatServer
{
    private readonly UdpClient _server = new(ServerSettings.PORT);
    
    private readonly ConcurrentDictionary<string, (IPEndPoint Endpoint, ClientInfo Info)> _clients = new();
    private readonly ConcurrentDictionary<string, (ChatContent Message, DateTime SentTime)> _pendingAcks = new();

    //Threads
    private readonly Thread _heartbeatThread;
    private readonly Thread _receiveThread;
    private readonly Thread _retryThread;

    private bool _isRunning;

    public ChatServer()
    {
        _receiveThread = new Thread(ReceiveMessages);
        _heartbeatThread = new Thread(CheckClientsAlive);
        _retryThread = new Thread(RetryPendingMessages);
    }

    public void Start()
    {
        _isRunning = true;
        Console.WriteLine($"Сервер запущен на порту {ServerSettings.PORT}");

        _receiveThread.Start();
        _heartbeatThread.Start();
        _retryThread.Start();
    }

    private void ReceiveMessages()
    {
        while (_isRunning)
        {
            try
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                var data = _server.Receive(ref remoteEndPoint);
                ProcessMessage(data, remoteEndPoint);
            }
            catch (SocketException)
            {
                // Игнорируем ошибки сокета при закрытии
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении сообщения: {ex.Message}");
            }
        }
    }

    private void ProcessMessage(byte[] data, IPEndPoint? endpoint)
    {
        try
        {
            var json = Encoding.UTF8.GetString(data);
            var message = JsonSerializer.Deserialize<ChatContent>(json);

            switch (message.MessageType)
            {
                case MessageTypes.UserJoined:
                    HandleUserJoined(message, endpoint);
                    break;

                case MessageTypes.IsAlive:
                    HandleHeartbeat(message.SenderName, endpoint);
                    break;

                case MessageTypes.Ack:
                    HandleAck(message.MessageId);
                    break;

                case MessageTypes.ChatMessage:
                    BroadcastMessage(message, endpoint);
                    break;

                case MessageTypes.UserLeft:
                    HandleUserLeft(message.SenderName);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка обработки сообщения: {ex.Message}");
        }
    }

    private void HandleUserJoined(ChatContent content, IPEndPoint? endpoint)
    {
        var clientInfo = new ClientInfo
        {
            Username = content.SenderName,
            IsPremium = content.IsPremium,
            LastHeartbeat = DateTime.Now
        };

        _clients.TryAdd(content.SenderName, (endpoint, clientInfo));

        BroadcastMessage(new ChatContent
        {
            MessageType = MessageTypes.SystemMessage,
            Content = $"{content.SenderName} присоединился к чату",
            Timestamp = DateTime.Now,
            RequiresAck = true
        });
    }

    private void HandleHeartbeat(string username, IPEndPoint? endpoint)
    {
        if (_clients.TryGetValue(username, out var client))
        {
            client.Info.LastHeartbeat = DateTime.Now;
            _clients.TryUpdate(username, (endpoint, client.Info), client);
        }
    }

    private void HandleAck(string messageId)
    {
        _pendingAcks.TryRemove(messageId, out _);
    }

    private void HandleUserLeft(string username)
    {
        if (_clients.TryRemove(username, out _))
            BroadcastMessage(new ChatContent
            {
                MessageType = MessageTypes.SystemMessage,
                Content = $"{username} покинул чат",
                Timestamp = DateTime.Now,
                RequiresAck = true
            });
    }

    private void BroadcastMessage(ChatContent content, IPEndPoint? excludeEndpoint = null)
    {
        var json = JsonSerializer.Serialize(content);
        var data = Encoding.UTF8.GetBytes(json);

        if (content.RequiresAck) _pendingAcks.TryAdd(content.MessageId, (content, DateTime.Now));

        foreach (var client in _clients)
        {
            if (client.Value.Endpoint.Equals(excludeEndpoint))
                continue;

            try
            {
                _server.Send(data, data.Length, client.Value.Endpoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка отправки сообщения клиенту {client.Key}: {ex.Message}");
            }
        }
    }

    private void CheckClientsAlive()
    {
        while (_isRunning)
        {
            var now = DateTime.Now;
            var deadClients = _clients.Where(c =>
                    (now - c.Value.Info.LastHeartbeat).TotalMilliseconds > ServerSettings.CLIENT_TIMEOUT)
                .Select(c => c.Key)
                .ToList();

            foreach (var username in deadClients) HandleUserLeft(username);

            Thread.Sleep(ServerSettings.HEARTBEAT_INTERVAL);
        }
    }

    private void RetryPendingMessages()
    {
        while (_isRunning)
        {
            var now = DateTime.Now;
            var messagesToRetry = _pendingAcks
                .Where(p => (now - p.Value.SentTime).TotalMilliseconds > ServerSettings.MESSAGE_RETRY_INTERVAL)
                .Select(p => p.Value.Message)
                .ToList();

            foreach (var message in messagesToRetry) BroadcastMessage(message);

            Thread.Sleep(ServerSettings.MESSAGE_RETRY_INTERVAL);
        }
    }

    public void Stop()
    {
        _isRunning = false;

        _server.Close();

        _receiveThread.Join();
        _heartbeatThread.Join();
        _retryThread.Join();
    }
}