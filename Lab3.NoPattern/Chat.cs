using Lab3.NoPattern.Client;
using Lab3.Server.Models;

namespace Lab3.NoPattern;

public partial class Chat : Form
{
    private readonly UserService _userService;
    public Chat(UserService userService)
    {
        _userService = userService;

        InitializeComponent();

        userService.OnMessageReceived += ReceiveMessage;
    }

    private void ReceiveMessage(ChatContent chatContent)
    {
        var senderName = chatContent.SenderName;
        var message = chatContent.Content;
        
        var text = chatContent.IsPremium ? chatContent.SenderName + $"[VIP]:  {message}" : senderName + ": " + message;
        
        ChatBox.Items.Add(text);
    }


    private void SendButton_Click(object sender, EventArgs e)
    {
        var message = MessageTextBox.Text;
        if (string.IsNullOrWhiteSpace(message))
            return;
        
        _userService.SendMessage(message);
        
        ChatBox.Items.Add(message);
        
        MessageTextBox.Clear();
    }
    
    

    private void DisconnectButton_Click(object sender, EventArgs e)
    {
        _userService.Disconnect();
        
        Application.Exit();
    }
}