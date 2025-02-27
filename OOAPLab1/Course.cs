namespace OOAPLabs;

public class Course
{
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    
    public ICollection<Student> Students { get; set; }
    
}