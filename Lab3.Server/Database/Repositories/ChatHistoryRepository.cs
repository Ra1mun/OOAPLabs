using Lab3.Server.Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab3.Server.Database.Repositories;

public interface IChatMessageRepository
{
    void InsertMessage(ChatMessage message);
    List<ChatMessage> GetAllMessages();

}

public class ChatHistoryRepository : IChatMessageRepository
{
    private readonly IMongoCollection<ChatMessage> _collection;
    
    public ChatHistoryRepository(ChatHistoryDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _collection = database.GetCollection<ChatMessage>(settings.CollectionName);
    }
    
    public void InsertMessage(ChatMessage message)
    {
        _collection.InsertOne(message);
    }

    public List<ChatMessage> GetAllMessages()
    {
        return _collection.Find(new BsonDocument()).ToList();
    }
}