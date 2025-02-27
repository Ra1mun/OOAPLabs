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
        textBoxTeacherName = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBoxDepartment = new System.Windows.Forms.TextBox();
        comboBoxCourse = new System.Windows.Forms.ComboBox();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        textBoxGroup = new System.Windows.Forms.TextBox();
        label5 = new System.Windows.Forms.Label();
        textBoxStudentName = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        checkedListBox1 = new System.Windows.Forms.CheckedListBox();
        label6 = new System.Windows.Forms.Label();
        listBox1 = new System.Windows.Forms.ListBox();
        label7 = new System.Windows.Forms.Label();
        comboBox2 = new System.Windows.Forms.ComboBox();
        label8 = new System.Windows.Forms.Label();
        button3 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // textBoxTeacherName
        // 
        textBoxTeacherName.Location = new System.Drawing.Point(11, 33);
        textBoxTeacherName.Name = "textBoxTeacherName";
        textBoxTeacherName.Size = new System.Drawing.Size(154, 23);
        textBoxTeacherName.TabIndex = 0;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(11, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(154, 21);
        label1.TabIndex = 1;
        label1.Text = "ФИО Преподавателя";
        label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(171, 9);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(154, 21);
        label2.TabIndex = 3;
        label2.Text = "Кафедра";
        label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // textBoxDepartment
        // 
        textBoxDepartment.Location = new System.Drawing.Point(171, 33);
        textBoxDepartment.Name = "textBoxDepartment";
        textBoxDepartment.Size = new System.Drawing.Size(154, 23);
        textBoxDepartment.TabIndex = 2;
        // 
        // comboBoxCourse
        // 
        comboBoxCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxCourse.FormattingEnabled = true;
        comboBoxCourse.Items.AddRange(new object[] { "База данных", "Программирование", "Компьютерные сети" });
        comboBoxCourse.Location = new System.Drawing.Point(334, 32);
        comboBoxCourse.Name = "comboBoxCourse";
        comboBoxCourse.Size = new System.Drawing.Size(169, 23);
        comboBoxCourse.TabIndex = 4;
        comboBoxCourse.SelectedIndexChanged += ComboBoxCourseSelectedIndexChanged;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(334, 8);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(169, 21);
        label3.TabIndex = 5;
        label3.Text = "Курс подготовки";
        label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(171, 78);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(154, 21);
        label4.TabIndex = 9;
        label4.Text = "Группа";
        label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // textBoxGroup
        // 
        textBoxGroup.Location = new System.Drawing.Point(171, 102);
        textBoxGroup.Name = "textBoxGroup";
        textBoxGroup.Size = new System.Drawing.Size(154, 23);
        textBoxGroup.TabIndex = 8;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(11, 78);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(154, 21);
        label5.TabIndex = 7;
        label5.Text = "Имя студента";
        label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // textBoxStudentName
        // 
        textBoxStudentName.Location = new System.Drawing.Point(11, 102);
        textBoxStudentName.Name = "textBoxStudentName";
        textBoxStudentName.Size = new System.Drawing.Size(154, 23);
        textBoxStudentName.TabIndex = 6;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(509, 33);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(100, 23);
        button1.TabIndex = 10;
        button1.Text = "Создать";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(334, 102);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(142, 27);
        button2.TabIndex = 11;
        button2.Text = "Добавить студента";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // checkedListBox1
        // 
        checkedListBox1.FormattingEnabled = true;
        checkedListBox1.Location = new System.Drawing.Point(11, 166);
        checkedListBox1.Name = "checkedListBox1";
        checkedListBox1.Size = new System.Drawing.Size(305, 400);
        checkedListBox1.TabIndex = 12;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(91, 142);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(154, 21);
        label6.TabIndex = 13;
        label6.Text = "Студенты";
        label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new System.Drawing.Point(520, 169);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(271, 409);
        listBox1.TabIndex = 14;
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(541, 145);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(206, 21);
        label7.TabIndex = 15;
        label7.Text = "Курсы и студенты";
        label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // comboBox2
        // 
        comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new System.Drawing.Point(334, 169);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new System.Drawing.Size(169, 23);
        comboBox2.TabIndex = 16;
        comboBox2.UseWaitCursor = true;
        // 
        // label8
        // 
        label8.Location = new System.Drawing.Point(334, 142);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(169, 21);
        label8.TabIndex = 17;
        label8.Text = "Курс";
        label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(373, 198);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(93, 28);
        button3.TabIndex = 18;
        button3.Text = "Привязать";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(803, 598);
        Controls.Add(button3);
        Controls.Add(label8);
        Controls.Add(comboBox2);
        Controls.Add(label7);
        Controls.Add(listBox1);
        Controls.Add(label6);
        Controls.Add(checkedListBox1);
        Controls.Add(button2);
        Controls.Add(button1);
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
        Location = new System.Drawing.Point(15, 15);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.ComboBox comboBox2;

    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBoxStudentName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxGroup;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxDepartment;
    private System.Windows.Forms.ComboBox comboBoxCourse;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.TextBox textBoxTeacherName;
    private System.Windows.Forms.Label label1;

    #endregion
}