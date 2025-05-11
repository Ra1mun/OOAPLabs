using System.ComponentModel;

namespace Lab4.NoPattern;

partial class Chat
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        MessageTextBox = new System.Windows.Forms.TextBox();
        SendButton = new System.Windows.Forms.Button();
        ChatBox = new System.Windows.Forms.ListBox();
        DisconnectButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // MessageTextBox
        // 
        MessageTextBox.Location = new System.Drawing.Point(12, 607);
        MessageTextBox.Name = "MessageTextBox";
        MessageTextBox.Size = new System.Drawing.Size(566, 23);
        MessageTextBox.TabIndex = 0;
        // 
        // SendButton
        // 
        SendButton.Location = new System.Drawing.Point(594, 607);
        SendButton.Name = "SendButton";
        SendButton.Size = new System.Drawing.Size(107, 23);
        SendButton.TabIndex = 1;
        SendButton.Text = "Отправить";
        SendButton.UseVisualStyleBackColor = true;
        SendButton.Click += SendButton_Click;
        // 
        // ChatBox
        // 
        ChatBox.FormattingEnabled = true;
        ChatBox.ItemHeight = 15;
        ChatBox.Location = new System.Drawing.Point(15, 14);
        ChatBox.Name = "ChatBox";
        ChatBox.Size = new System.Drawing.Size(686, 574);
        ChatBox.TabIndex = 2;
        // 
        // DisconnectButton
        // 
        DisconnectButton.BackColor = System.Drawing.Color.Red;
        DisconnectButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        DisconnectButton.Location = new System.Drawing.Point(712, 12);
        DisconnectButton.Name = "DisconnectButton";
        DisconnectButton.Size = new System.Drawing.Size(117, 38);
        DisconnectButton.TabIndex = 3;
        DisconnectButton.Text = "Отключиться";
        DisconnectButton.UseVisualStyleBackColor = false;
        DisconnectButton.Click += DisconnectButton_Click;
        // 
        // Chat
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(841, 642);
        Controls.Add(DisconnectButton);
        Controls.Add(ChatBox);
        Controls.Add(SendButton);
        Controls.Add(MessageTextBox);
        Text = "Chat";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button DisconnectButton;

    private System.Windows.Forms.ListBox ChatBox;

    private System.Windows.Forms.TextBox MessageTextBox;
    private System.Windows.Forms.Button SendButton;

    #endregion
}