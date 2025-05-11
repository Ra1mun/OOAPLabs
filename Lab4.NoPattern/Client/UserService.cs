using Lab3.Server.Models;

namespace Lab4.NoPattern.Client;

public class UserService
{
    public event Action<string>? OnMessageReceived;
    
    private readonly User _user;
    private readonly IChatMediator _chat;
    
    private readonly Dictionary<string, string> _emojiMap = new()
    {
        { ":)", "😊" },
        { ":(", "😢" },
        { ":D", "😃" },
        { ":P", "😛" },
        { "<3", "❤️" }
    };

    public UserService(User user, IChatMediator chat)
    {
        _user = user;
        _chat = chat;
        
        _chat.MessageReceived += ReceiveMessage;
    }
    
    private void ReceiveMessage(ChatContent content)
    {
        var message = content.Content;
        var senderName = content.SenderName;
        
        string text;
        if (content.MessageType == MessageTypes.SystemMessage)
        {
            text = message;
        }
        else
        {
            text = content.IsPremium ? senderName + $"[VIP]:  {message}" : senderName + ": " + message;
        }
        
        var processMessage = ProcessMessage(text);

        OnMessageReceived?.Invoke(processMessage);
    }

    public string SendMessage(string message)
    {
        var text = message.Trim();
        if (text.Length == 0)
            return null;

        var processedMessage = ProcessMessage(text);
        
        _chat.SendMessage(processedMessage);
        
        return _user.Premium ? _user.Username + $"[VIP]:  {processedMessage}" : _user.Username + ": " + processedMessage;
    }
    
    private string ProcessMessage(string message)
    {
        var processedMessage = _emojiMap.Aggregate(message, (current, emoji) => current.Replace(emoji.Key, emoji.Value));

        return processedMessage;
    }

    public void Disconnect()
    {
        _chat.Disconnect();
    }
    
    
}