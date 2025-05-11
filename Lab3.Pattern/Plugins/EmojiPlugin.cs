using Lab3.Pattern.Client;

namespace Lab3.Pattern.Plugins
{
    public class EmojiPlugin : BaseChatPlugin
    {
        private readonly Dictionary<string, string> _emojiMap;

        public EmojiPlugin()
        {
            _emojiMap = new Dictionary<string, string>
            {
                { ":)", "😊" },
                { ":(", "😢" },
                { ":D", "😃" },
                { ":P", "😛" },
                { "<3", "❤️" }
            };
        }

        public override string Name => "Emoji Support";
        public override string Description => "Converts text emoticons to emoji";

        public override string ProcessMessage(string message, User sender)
        {
            var processedMessage = _emojiMap.Aggregate(message, (current, emoji) => current.Replace(emoji.Key, emoji.Value));

            return processedMessage;
        }
    }
} 