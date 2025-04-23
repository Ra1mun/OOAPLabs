namespace Lab3.Server.Server;

public class ClientInfo
{
    public string Username { get; set; }
    public bool IsPremium { get; set; }
    public DateTime LastHeartbeat { get; set; }
}

public class ServerSettings
{
    public const int PORT = 5000;
    public const int HEARTBEAT_INTERVAL = 5000; // 5 seconds
    public const int CLIENT_TIMEOUT = 15000; // 15 seconds
    public const int MESSAGE_RETRY_INTERVAL = 1000; // 1 second
    public const string IP_ADDRESS = "127.0.0.1";
}