using Lab3.Pattern.Client;
using Lab3.Server.Models;

namespace Lab3.Pattern;

public partial class Chat : Form
{
    private readonly Participant _participant;
    public Chat(Participant participant)
    {
        _participant = participant;

        InitializeComponent();

        participant.OnMessageReceived += ReceiveMessage;
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
        
        var text = _participant.SendMessage(message);
        if (string.IsNullOrWhiteSpace(text))
            return;
        
        ChatBox.Items.Add(text);
        
        MessageTextBox.Clear();
    }

    private void DisconnectButton_Click(object sender, EventArgs e)
    {
        _participant.Disconnect();
        
        Application.Exit();
    }
}