using Lab3.Server.Server;

var server = new ChatServer();
server.Start();

Console.WriteLine("Нажмите Enter для остановки сервера...");
Console.ReadLine();

server.Stop();

