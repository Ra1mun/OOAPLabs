using System.Text;
using OOAPLabs;

namespace OOAPLab1;

public partial class Form1 : Form
{
    private Dictionary<string, Func<BaseCourseBuilder>> _courseBuildersMap = new()
    {
        { "База данных", () => new DataBaseCourseBuilder() },
        { "Программирование", () => new ProgrammingCourseBuilder() },
        { "Компьютерные сети", () => new ComputerNetworkCourseBuilder() }
    };
    private Dictionary<string, BaseCourseBuilder> _courseBuilders = new();
    private  BaseCourseBuilder? _currentBuilder;
    
    public Form1()
    {
        InitializeComponent();
    }

    private void ComboBoxCourseSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = comboBoxCourse.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(selectedItem) || !_courseBuildersMap.ContainsKey(selectedItem))
            return;

        _currentBuilder = _courseBuildersMap[selectedItem].Invoke();
        _currentBuilder.CreateCourse();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var teacherName = textBoxTeacherName.Text.Trim();
        var department = textBoxDepartment.Text.Trim();
        if (string.IsNullOrEmpty(teacherName) || string.IsNullOrEmpty(department) || _currentBuilder == null)
        {
            return;
        }
        
        var key = teacherName + " " + _currentBuilder.Name;
        if (!_courseBuilders.TryAdd(key, _currentBuilder))
        {
            return;
        }
        
        _currentBuilder.SetTeacher(teacherName, department);
        comboBox2.Items.Add(key);
        
        ClearTextBoxes(textBoxTeacherName, textBoxDepartment);
        comboBoxCourse.Text = "";
        _currentBuilder = null;
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

    private void button3_Click(object sender, EventArgs e)
    {
        var selectedCourse = comboBox2.SelectedItem.ToString();
        var students = checkedListBox1.SelectedItems;
        if (!_courseBuilders.TryGetValue(selectedCourse, out var builder) && students.Count == 0)
        {
            return;
        }
        
        builder.SetStudents(students);
        var course = builder.Build();
        listBox1.Items.Add(course.Teacher.Name);
        listBox1.Items.Add(course.Name);
        listBox1.Items.Add("Студенты:");
        foreach (var student in course.Students)
        {
            listBox1.Items.Add(student.Name + student.GroupId + "\n");
        }
    }
    
    private void ClearTextBoxes(params TextBox[] textboxes)
    {
        foreach (var textbox in textboxes)
        {
            textbox.Clear();
        }
    }
}