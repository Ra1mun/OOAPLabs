using System.Text;
using OOAPLabs;

namespace OOAPLab1;

public partial class Form1 : Form
{
    private readonly List<ICourse> _courses = new();
    public Form1()
    {
        InitializeComponent();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        var studentName = textBoxStudentName.Text;
        var group = textBoxGroup.Text;
        if (string.IsNullOrEmpty(studentName) || !int.TryParse(group, out var groupId))
        {
            return;
        }

        checkedListBox1.Items.Add(studentName + " " + groupId);
        ClearTextBoxes(textBoxStudentName, textBoxGroup);
    }

    private void ClearTextBoxes(params TextBox[] textboxes)
    {
        foreach (var textbox in textboxes)
        {
            textbox.Clear();
        }
    }

    private void buttonRelation_Click(object sender, EventArgs e)
    {
        var students = checkedListBox1.SelectedItems;
        var teacherName = textBoxTeacherName.Text;
        var course = GetCourse();
        var department = textBoxDepartment.Text;
        if (course == null ||
            students.Count == 0 || 
            string.IsNullOrEmpty(teacherName) ||
            string.IsNullOrEmpty(department))
            return;

        FillCourse(course, teacherName, department, students);
        listBox1.Items.Add(course.Teacher.Name);
        listBox1.Items.Add(course.Name);
        listBox1.Items.Add("Студенты:");
        foreach (var student in course.Students)
        {
            listBox1.Items.Add(student.Name + student.GroupId + "\n");
        }
    }

    private void FillCourse(ICourse course, string teacherName, string department, ListBox.SelectedObjectCollection students)
    {
        course.Teacher = new Teacher(teacherName, department);
        foreach (var student in students)
        {
            var elements = student.ToString().Split(' ');
            var studentName = elements[0];
            var studentGroupId = int.Parse(elements[1]);
            var studentDto = new Student(studentName, studentGroupId);
            course.Students.Add(studentDto);
        }
        _courses.Add(course);
    }

    private ICourse? GetCourse()
    {
        return comboBoxCourse.SelectedItem?.ToString() switch
        {
            "База данных" => new DatabaseCourse(),
            "Компьютерные сети" => new ComputerNetwork(),
            "Программирование" => new Programming(),
            _ => null
        };
    }
}