using OOAPLabs;

namespace OOAPLab1;

public interface ICourse
{
    string Name { get; set; }
    Teacher Teacher { get; set; }

    List<Student> Students { get; set; }
}

public class DatabaseCourse : ICourse
{
    public string Name { get; set; } = "Базы данных";
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; } = new();
}

public class ComputerNetwork : ICourse
{
    public string Name { get; set; } = "Компьютерные сети";
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; } = new();
}

public class Programming : ICourse
{
    public string Name { get; set; } = "Программирование";
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; } = new();
}
