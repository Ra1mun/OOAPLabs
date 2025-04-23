using Lab3.Pattern.Client;

namespace Lab3.Pattern;

public partial class Login : Form
{
    public Login()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        var username = textBox1.Text;
        var premium = checkBox1.Checked;
        if (string.IsNullOrEmpty(username)) MessageBox.Show("Пожалуйста, введите имя пользователя");

        var user = new User
        {
            Username = username,
            Premium = premium
        };

        var chatRoom = new ChatClient(user);
        chatRoom.Connect();

        var participant = new Participant(user, chatRoom);

        var chat = new Chat(participant);
        chat.Show();

        Hide();
    }
}