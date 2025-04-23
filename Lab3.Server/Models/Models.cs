namespace Lab3.Server.Models;

public static class MessageTypes
{
    public const string UserJoined = "USER_JOINED";
    public const string UserLeft = "USER_LEFT";
    public const string ChatMessage = "CHAT_MESSAGE";
    public const string SystemMessage = "SYSTEM_MESSAGE";
    public const string IsAlive = "IsAlive";
    public const string Ack = "ACK";
}

public class ChatContent
{
    public string MessageId { get; set; } = Guid.NewGuid().ToString();
    public string MessageType { get; set; }
    public string SenderName { get; set; }
    public string Content { get; set; }
    public bool IsPremium { get; set; }
    public DateTime Timestamp { get; set; }
    public bool RequiresAck { get; set; }
}
