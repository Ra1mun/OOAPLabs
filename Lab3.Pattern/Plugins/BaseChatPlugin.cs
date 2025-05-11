using Lab3.Pattern.Client;

namespace Lab3.Pattern.Plugins
{
    public interface IChatPlugin
    {
        string Name { get; }
        string Description { get; }
        string ProcessMessage(string message, User sender);
        void OnUserConnected(User user);
        void OnUserDisconnected(User user);
    }
    
    public abstract class BaseChatPlugin : IChatPlugin
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public virtual string ProcessMessage(string message, User sender) { return message; }
        
        public virtual void OnUserConnected(User user) { }
        
        public virtual void OnUserDisconnected(User user) { }
    }
} 