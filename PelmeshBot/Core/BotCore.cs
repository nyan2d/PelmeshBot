using PelmeshBot.Core.Commands;
using PelmeshBot.Extensions;
using PelmeshBot.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace PelmeshBot.Core
{
    class BotCore
    {
        private readonly ITelegramBotClient _client;
        private readonly ILogger _logger;
        private ICollection<ICommand> _commands;

        public BotCore(string token, ILogger logger)
        {
            _logger = logger;

            _client = new TelegramBotClient(token);
            _client.OnMessage += _client_OnMessage;
            _logger.Info("Бот создан.");

            LoadCommands();
            _logger.Info("Команды загружены.");
        }

        public void Start()
        {
            _client.StartReceiving();
            _logger.Info("Бот запущен.");
        }

        private void LoadCommands()
        {
            _commands = new List<ICommand>
            {
                new RollCommand(),
                new PickCommand(),
            };
        }

        private void _client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            _logger.Debug($"Получено сообщение. Тип: {e.Message.Type}");
            if (e.Message.Type == MessageType.Text)
            {
                _commands.Where(x => x.CanExecute(e.Message))
                         .ForEach(x => x.Execute(e.Message).Execute(_client));
            }
        }
    }
}
