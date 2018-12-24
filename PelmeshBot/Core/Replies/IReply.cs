using System.Threading.Tasks;
using Telegram.Bot;

namespace PelmeshBot.Core.Replies
{
    interface IReply
    {
        Task Execute(ITelegramBotClient client);
    }
}
