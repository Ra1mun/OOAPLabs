using System.Net;
using System.Net.Sockets;
using Lab3.NoPattern.Client;
using Lab3.Server.Models;
using Lab3.Server.Server;

namespace Lab3.NoPattern;

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

        var updClient = Connect();

        var userService = new UserService(user, updClient);

        var chat = new Chat(userService);
        chat.Show();

        Hide();
    }

    private static UdpClient Connect()
    {
        var serverEndPoint = new IPEndPoint(IPAddress.Parse(ServerSettings.IP_ADDRESS), ServerSettings.PORT);
        
        var updClient = new UdpClient();
        
        updClient.Connect(serverEndPoint);

        return updClient;
    }
}