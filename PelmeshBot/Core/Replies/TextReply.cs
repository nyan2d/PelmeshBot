using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PelmeshBot.Core.Replies
{
    class TextReply : IReply
    {
        public ChatId ChatId { get; set; }

        public string Text { get; set; }

        public ParseMode ParseMode { get; set; }

        public bool DisableWebPagePreview { get; set; }

        public bool DisableNotification { get; set; }

        public int ReplyToMessageId { get; set; }

        public IReplyMarkup ReplyMarkup { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public TextReply(ChatId chatId, string text, ParseMode parseMode = ParseMode.Default,
            bool disableWebPagePreview = false, bool disableNotification = false,
            int replyToMessageId = 0, IReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ChatId = chatId;
            Text = text;
            ParseMode = parseMode;
            DisableWebPagePreview = disableWebPagePreview;
            DisableNotification = disableNotification;
            ReplyToMessageId = replyToMessageId;
            ReplyMarkup = replyMarkup;
            CancellationToken = cancellationToken;
        }

        public Task Execute(ITelegramBotClient client) => client.SendTextMessageAsync(ChatId, Text,
            ParseMode, DisableWebPagePreview, DisableNotification, ReplyToMessageId, ReplyMarkup, CancellationToken);
    }
}
