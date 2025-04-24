
namespace Lab3.NoPattern.Client;

public record User
{
    public required string Username { get; init; }
    
    public bool Premium { get; init; }
}