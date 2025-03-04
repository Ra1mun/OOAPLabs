namespace OOAPLabs;

public interface IEntites
{
    public string Name { get; init; }
}

public record Student(string Name, int GroupId) : IEntites;

public record Teacher(string Name, string Department) : IEntites;