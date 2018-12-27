using System;
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
            var min = 1;
            var max = 98;

            var cmd = CommandMessage.Parse(message.Text);
            var split = cmd.Arguments.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            if (split.Length > 0)
            {
                // чекаем первый аргумент
                if (int.TryParse(split[0], out int first))
                {
                    // чекаем второй аргумент
                    if (split.Length > 1 && int.TryParse(split[1], out int second))
                    {
                        // команда с двумя правильными аргументами
                        min = first;
                        max = second;
                    } else
                    {
                        // команда с одним правильным аргументом
                        max = first;
                    }
                }
            }

            // фиксим лимиты
            if (max < 1) max = 1;
            if (min < 1) min = 1;
            if (max < min)
            {
                var tmp = min;
                min = max;
                max = tmp;
            }

            var roll = _random.Next(min, max + 1);
            return new TextReply(message.Chat.Id, roll.ToString(), replyToMessageId: message.MessageId);
        }
    }
}
