using Lab4.NoPattern.Client;

namespace Lab4.NoPattern;

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

        var service = ConfigureChat(user);

        var chat = new Chat(service);
        chat.Show();

        Hide();
    }

    private static UserService ConfigureChat(User user)
    {
        var chatRoom = SetupMediator(user);

        var service = SetupServices(user, chatRoom);
        
        return service;
    }
    private static UserService SetupServices(User user, IChatMediator chatRoom)
    {
        return new UserService(user, chatRoom);
    }

    private static IChatMediator SetupMediator(User user)
    {
        IChatMediator chatRoom = new ChatMediator(user);
        chatRoom.Connect();
        
        return chatRoom;
    }
}