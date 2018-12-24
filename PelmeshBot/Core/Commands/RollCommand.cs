using System;
using System.Linq;
using PelmeshBot.Core.Replies;
using Telegram.Bot.Types;

namespace PelmeshBot.Core.Commands
{
    class RollCommand : ICommand
    {
        private static Random _random = new Random();

        public bool CanExecute(Message message) => CommandMessage.Parse(message.Text).Is("ROLL");

        public IReply Execute(Message message)
        {
            var cmd = CommandMessage.Parse(message.Text);
            var limit = 99;
            if (cmd.Arguments.Length > 0)
            {
                var split = cmd.Arguments.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(split.First(), out int ulimit))
                {
                    if (ulimit > 0)
                    {
                        limit = ulimit;
                    }
                }
                else
                {
                    return new TextReply(message.Chat.Id, "Ты дебил?", replyToMessageId: message.MessageId);
                }
            }
            return new TextReply(message.Chat.Id, $"{_random.Next(limit)+1}", replyToMessageId: message.MessageId);
        }
    }
}
