using Lab3.Server.Database.Models;
using Lab3.Server.Database.Repositories;
using Lab3.Server.Database.Service;
using Lab3.Server.Server;

var service = SetupDatabase();

var server = new ChatServer(service);
server.Start();

Console.WriteLine("Нажмите Enter для остановки сервера...");
Console.ReadLine();

server.Stop();

ChatHistoryService SetupDatabase()
{
    var settings = new ChatHistoryDatabaseSettings
    {
        ConnectionString = "mongodb://localhost:27017",
        DatabaseName = "OOAP",
        CollectionName = "History",
    };
        
    var repository = new ChatHistoryRepository(settings);
        
    return new ChatHistoryService(repository);
}