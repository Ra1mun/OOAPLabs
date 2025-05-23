﻿using Lab3.Pattern.Plugins;
using Lab3.Server.Models;

namespace Lab3.Pattern.Client;

public class UserService
{
    public event Action<string>? OnMessageReceived;
    
    private readonly User _user;
    private readonly IChatMediator _chat;
    private readonly List<IChatPlugin> _plugins = new();

    public UserService(User user, IChatMediator chat)
    {
        _user = user;
        _chat = chat;
        
        _chat.MessageReceived += ReceiveMessage;
    }
    
    private void ReceiveMessage(ChatContent content)
    {
        var message = content.Content;
        var senderName = content.SenderName;
        
        string text;
        if (content.MessageType == MessageTypes.SystemMessage)
        {
            text = message;
        }
        else
        {
            text = content.IsPremium ? senderName + $"[VIP]:  {message}" : senderName + ": " + message;
        }
        
        var processMessage = ProcessMessage(text);

        OnMessageReceived?.Invoke(processMessage);
    }

    public string SendMessage(string message)
    {
        var text = message.Trim();
        if (text.Length == 0)
            return null;

        var processedMessage = ProcessMessage(text);
        
        _chat.SendMessage(processedMessage);
        
        return _user.Premium ? _user.Username + $"[VIP]:  {processedMessage}" : _user.Username + ": " + processedMessage;
    }
    
    public void RegisterPlugin(IChatPlugin plugin)
    {
        if (!_plugins.Contains(plugin))
        {
            _plugins.Add(plugin);
        }
    }

    public void UnregisterPlugin(IChatPlugin plugin)
    {
        _plugins.Remove(plugin);
    }
    
    private string ProcessMessage(string message)
    {
        string processedMessage = null;
        foreach (var plugin in _plugins)
        {
                    
            if (string.IsNullOrEmpty(processedMessage))
                processedMessage = plugin.ProcessMessage(message, _user);

            processedMessage = plugin.ProcessMessage(processedMessage, _user);
        }
        
        return processedMessage;
    }

    public void Disconnect()
    {
        _chat.Disconnect();
    }
    
    
}