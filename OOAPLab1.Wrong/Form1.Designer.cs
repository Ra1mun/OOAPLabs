namespace OOAPLab1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        textBoxTeacherName = new TextBox();
        label1 = new Label();
        label2 = new Label();
        textBoxDepartment = new TextBox();
        label3 = new Label();
        label4 = new Label();
        textBoxGroup = new TextBox();
        label5 = new Label();
        textBoxStudentName = new TextBox();
        button2 = new Button();
        checkedListBox1 = new CheckedListBox();
        label6 = new Label();
        listBox1 = new ListBox();
        label7 = new Label();
        comboBoxCourse = new ComboBox();
        buttonRelation = new Button();
        SuspendLayout();
        // 
        // textBoxTeacherName
        // 
        textBoxTeacherName.Location = new Point(13, 44);
        textBoxTeacherName.Margin = new Padding(3, 4, 3, 4);
        textBoxTeacherName.Name = "textBoxTeacherName";
        textBoxTeacherName.Size = new Size(175, 27);
        textBoxTeacherName.TabIndex = 0;
        // 
        // label1
        // 
        label1.Location = new Point(13, 12);
        label1.Name = "label1";
        label1.Size = new Size(176, 28);
        label1.TabIndex = 1;
        label1.Text = "ФИО Преподавателя";
        label1.TextAlign = ContentAlignment.TopCenter;
        // 
        // label2
        // 
        label2.Location = new Point(195, 12);
        label2.Name = "label2";
        label2.Size = new Size(176, 28);
        label2.TabIndex = 3;
        label2.Text = "Кафедра";
        label2.TextAlign = ContentAlignment.TopCenter;
        // 
        // textBoxDepartment
        // 
        textBoxDepartment.Location = new Point(195, 44);
        textBoxDepartment.Margin = new Padding(3, 4, 3, 4);
        textBoxDepartment.Name = "textBoxDepartment";
        textBoxDepartment.Size = new Size(175, 27);
        textBoxDepartment.TabIndex = 2;
        // 
        // label3
        // 
        label3.Location = new Point(382, 11);
        label3.Name = "label3";
        label3.Size = new Size(193, 28);
        label3.TabIndex = 5;
        label3.Text = "Курс подготовки";
        label3.TextAlign = ContentAlignment.TopCenter;
        // 
        // label4
        // 
        label4.Location = new Point(195, 104);
        label4.Name = "label4";
        label4.Size = new Size(176, 28);
        label4.TabIndex = 9;
        label4.Text = "Группа";
        label4.TextAlign = ContentAlignment.TopCenter;
        // 
        // textBoxGroup
        // 
        textBoxGroup.Location = new Point(195, 136);
        textBoxGroup.Margin = new Padding(3, 4, 3, 4);
        textBoxGroup.Name = "textBoxGroup";
        textBoxGroup.Size = new Size(175, 27);
        textBoxGroup.TabIndex = 8;
        // 
        // label5
        // 
        label5.Location = new Point(13, 104);
        label5.Name = "label5";
        label5.Size = new Size(176, 28);
        label5.TabIndex = 7;
        label5.Text = "Имя студента";
        label5.TextAlign = ContentAlignment.TopCenter;
        // 
        // textBoxStudentName
        // 
        textBoxStudentName.Location = new Point(13, 136);
        textBoxStudentName.Margin = new Padding(3, 4, 3, 4);
        textBoxStudentName.Name = "textBoxStudentName";
        textBoxStudentName.Size = new Size(175, 27);
        textBoxStudentName.TabIndex = 6;
        // 
        // button2
        // 
        button2.Location = new Point(382, 136);
        button2.Margin = new Padding(3, 4, 3, 4);
        button2.Name = "button2";
        button2.Size = new Size(162, 36);
        button2.TabIndex = 11;
        button2.Text = "Добавить студента";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // checkedListBox1
        // 
        checkedListBox1.FormattingEnabled = true;
        checkedListBox1.Location = new Point(13, 221);
        checkedListBox1.Margin = new Padding(3, 4, 3, 4);
        checkedListBox1.Name = "checkedListBox1";
        checkedListBox1.Size = new Size(348, 532);
        checkedListBox1.TabIndex = 12;
        // 
        // label6
        // 
        label6.Location = new Point(104, 189);
        label6.Name = "label6";
        label6.Size = new Size(176, 28);
        label6.TabIndex = 13;
        label6.Text = "Студенты";
        label6.TextAlign = ContentAlignment.TopCenter;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(594, 225);
        listBox1.Margin = new Padding(3, 4, 3, 4);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(309, 544);
        listBox1.TabIndex = 14;
        // 
        // label7
        // 
        label7.Location = new Point(618, 193);
        label7.Name = "label7";
        label7.Size = new Size(235, 28);
        label7.TabIndex = 15;
        label7.Text = "Курсы и студенты";
        label7.TextAlign = ContentAlignment.TopCenter;
        // 
        // comboBoxCourse
        // 
        comboBoxCourse.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxCourse.Items.AddRange(new object[] { "База данных", "Программирование", "Компьютерные сети" });
        comboBoxCourse.Location = new Point(382, 43);
        comboBoxCourse.Name = "comboBoxCourse";
        comboBoxCourse.Size = new Size(200, 28);
        comboBoxCourse.TabIndex = 16;
        // 
        // buttonRelation
        // 
        buttonRelation.Location = new Point(402, 221);
        buttonRelation.Name = "buttonRelation";
        buttonRelation.Size = new Size(128, 44);
        buttonRelation.TabIndex = 17;
        buttonRelation.Text = "Привязать";
        buttonRelation.UseVisualStyleBackColor = true;
        buttonRelation.Click += buttonRelation_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(918, 797);
        Controls.Add(buttonRelation);
        Controls.Add(label7);
        Controls.Add(listBox1);
        Controls.Add(label6);
        Controls.Add(checkedListBox1);
        Controls.Add(button2);
        Controls.Add(label4);
        Controls.Add(textBoxGroup);
        Controls.Add(label5);
        Controls.Add(textBoxStudentName);
        Controls.Add(label3);
        Controls.Add(comboBoxCourse);
        Controls.Add(label2);
        Controls.Add(textBoxDepartment);
        Controls.Add(label1);
        Controls.Add(textBoxTeacherName);
        Location = new Point(15, 15);
        Margin = new Padding(3, 4, 3, 4);
        Name = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBoxStudentName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxGroup;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxDepartment;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.TextBox textBoxTeacherName;
    private System.Windows.Forms.Label label1;

    #endregion

    private ComboBox comboBoxCourse;
    private Button buttonRelation;
}