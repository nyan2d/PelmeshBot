using PelmeshBot.Configuration;
using PelmeshBot.Core;
using PelmeshBot.Logging;
using System;
using System.Text;

namespace PelmeshBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var logger = new Logger(new ConsoleLogTarget());

            var config = ConfigManager.LoadConfig("default.json");
            CommandMessage.SetBotname(config.BotName);

            var bot = new BotCore(config.TelegramApiKey, logger);
            bot.Start();

            while (Console.ReadLine() != "exit") { }
        }
    }
}
