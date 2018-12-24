using System;
using PelmeshBot.Core.Replies;
using Telegram.Bot.Types;

namespace PelmeshBot.Core.Commands
{
    class PickCommand : ICommand
    {
        private static Random _random = new Random();

        public bool CanExecute(Message message) => CommandMessage.Parse(message.Text).Is("PICK");


        public IReply Execute(Message message)
        {
            var command = CommandMessage.Parse(message.Text);
            var split = command.Arguments.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length < 2)
            {
                return new TextReply(message.Chat.Id, "Ты дебил?", replyToMessageId: message.MessageId);
            }
            else
            {
                return new TextReply(message.Chat.Id,
                    split[_random.Next(split.Length)].Replace('_', ' '),
                    replyToMessageId: message.MessageId);
            }
        }
    }
}
