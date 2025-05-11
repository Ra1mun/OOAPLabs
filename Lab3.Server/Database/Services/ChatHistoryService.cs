using Lab3.Server.Database.Models;
using Lab3.Server.Database.Repositories;
using Lab3.Server.Models;

namespace Lab3.Server.Database.Service;

public interface IChatMessageService
{
    void AddMessage(ChatContent content);
    string[] GetAllHistory();
}

public class ChatHistoryService : IChatMessageService
{
    private readonly IChatMessageRepository _chatMessageRepository;

    public ChatHistoryService(IChatMessageRepository chatMessageRepository)
    {
        _chatMessageRepository = chatMessageRepository;
    }
    
    public void AddMessage(ChatContent content)
    {
        var message = new ChatMessage
        {
            Content = content.Content,
            Sender = new ChatUser
            {
                Name = content.SenderName,
                IsPremium = content.IsPremium
            },
            Timestamp = content.Timestamp
        };
        
        _chatMessageRepository.InsertMessage(message);
    }

    public string[] GetAllHistory()
    {
        throw new NotImplementedException();
    }
}