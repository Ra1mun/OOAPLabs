using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lab3.Server.Database.Models;

public class ChatMessage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Content { get; set; }
    public ChatUser Sender { get; set; }
    public DateTime Timestamp { get; set; }
}

public class ChatUser
{
    public string Name { get; set; }
    public bool IsPremium { get; set; }
}