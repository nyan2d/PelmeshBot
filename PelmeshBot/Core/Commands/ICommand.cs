using PelmeshBot.Core.Replies;
using Telegram.Bot.Types;

namespace PelmeshBot.Core.Commands
{
    interface ICommand
    {
        bool CanExecute(Message message);
        IReply Execute(Message message);
    }
}
