using Lab3.Pattern.Client;
using Lab3.Server.Models;

namespace Lab3.Pattern;

public class Participant
{
    public event Action<string>? OnMessageReceived;
    
    private readonly User _user;
    private readonly IChatMediator _chat;

    public Participant(User user, IChatMediator chat)
    {
        _user = user;
        _chat = chat;
        
        _chat.MessageReceived += ReceiveMessage;
    }
    
    private void ReceiveMessage(ChatContent content)
    {
        if (content.SenderName == _user.Username)
            return;
        
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

        OnMessageReceived?.Invoke(text);
    }

    public string? SendMessage(string message)
    {
        var text = message.Trim();
        if (text.Length == 0)
            return null;
        
        _chat.SendMessage(text);
        
        return _user.Premium ? _user.Username + $"[VIP]:  {message}" : _user.Username + ": " + message;
    }

    public void Disconnect()
    {
        _chat.Disconnect();
    }
}