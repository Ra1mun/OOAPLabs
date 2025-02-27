namespace OOAPLabs;

public abstract class BaseCourseBuilder
{
    public string Name;
    private readonly Course _course = new();
    
    public virtual BaseCourseBuilder CreateCourse()
    {
        _course.Name = Name;
        return this;
    }
    
    public virtual BaseCourseBuilder SetTeacher(string teacherName, string department)
    {
        var teacher = new Teacher(teacherName, department);
        _course.Teacher = teacher;
        return this;
    }

    public virtual BaseCourseBuilder SetStudents(ListBox.SelectedObjectCollection students)
    {
        var studentsList = new List<Student>();
        foreach (var student in students)
        {
            var elements = student.ToString().Split(' ');
            var studentName = elements[0];
            var studentGroupId = int.Parse(elements[1]);
            var studentDto = new Student(studentName, studentGroupId);
            if (_course.Students.Contains(studentDto))
            {
                continue;
            }
            _course.Students.Add(studentDto);
        }

        _course.Students = studentsList;
        return this;
    }

    public Course Build()
    {
        return _course;
    }
}

public class DataBaseCourseBuilder : BaseCourseBuilder
{
    public DataBaseCourseBuilder()
    {
        Name = "База данных";
    }

}

public class ProgrammingCourseBuilder : BaseCourseBuilder
{
    public ProgrammingCourseBuilder()
    {
        Name = "Программирование";
    }
}

public class ComputerNetworkCourseBuilder : BaseCourseBuilder
{
    public ComputerNetworkCourseBuilder()
    {
        Name = "Компьютерные сети";
    }
}