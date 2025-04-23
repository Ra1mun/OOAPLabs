namespace Lab3.Pattern;

partial class Login
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
        LoginButton = new System.Windows.Forms.Button();
        checkBox1 = new System.Windows.Forms.CheckBox();
        textBox1 = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // LoginButton
        // 
        LoginButton.Location = new System.Drawing.Point(12, 95);
        LoginButton.Name = "LoginButton";
        LoginButton.Size = new System.Drawing.Size(237, 42);
        LoginButton.TabIndex = 0;
        LoginButton.Text = "Войти";
        LoginButton.UseVisualStyleBackColor = true;
        LoginButton.Click += LoginButton_Click;
        // 
        // checkBox1
        // 
        checkBox1.Location = new System.Drawing.Point(12, 63);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new System.Drawing.Size(103, 23);
        checkBox1.TabIndex = 1;
        checkBox1.Text = "Premium";
        checkBox1.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(12, 34);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(237, 23);
        textBox1.TabIndex = 2;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(27, 7);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(205, 24);
        label1.TabIndex = 3;
        label1.Text = "Имя пользовтеля";
        label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // Login
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(266, 153);
        Controls.Add(label1);
        Controls.Add(textBox1);
        Controls.Add(checkBox1);
        Controls.Add(LoginButton);
        Text = "Login";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button LoginButton;
    private System.Windows.Forms.CheckBox checkBox1;

    #endregion
}