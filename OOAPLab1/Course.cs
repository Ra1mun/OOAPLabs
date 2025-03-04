using OOAPLabs;

namespace OOAPLab1;

public class Course
{
    public string Name { get; set; }
    public Teacher Teacher { get; set; }

    public List<Student> Students { get; set; } = new();
}

public class DatabaseCourse : Course;

public class ComputerNetwork : Course;

public class ProgrammingNetwork : Course;