namespace Lab3.Server.Database.Models;

public record ChatHistoryDatabaseSettings
{
    public string ConnectionString { get; init; }

    public string DatabaseName { get; init; }

    public string CollectionName { get; init; }
}