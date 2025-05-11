using Lab4.NoPattern.Client;

namespace Lab4.NoPattern;

public partial class Chat : Form
{
    private readonly UserService _userService;
    public Chat(UserService userService)
    {
        _userService = userService;

        InitializeComponent();

        userService.OnMessageReceived += ReceiveMessage;
    }

    private void ReceiveMessage(string message)
    {
        ChatBox.Items.Add(message);
    }


    private void SendButton_Click(object sender, EventArgs e)
    {
        var message = MessageTextBox.Text;
        if (string.IsNullOrWhiteSpace(message))
            return;
        
        var text = _userService.SendMessage(message);
        if (string.IsNullOrWhiteSpace(text))
            return;
        
        ChatBox.Items.Add(text);
        
        MessageTextBox.Clear();
    }

    private void DisconnectButton_Click(object sender, EventArgs e)
    {
        _userService.Disconnect();
        
        Application.Exit();
    }
}