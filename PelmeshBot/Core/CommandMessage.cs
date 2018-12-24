using System.Text.RegularExpressions;

namespace PelmeshBot.Core
{
    public class CommandMessage
    {
        private static Regex _rg = new Regex(@"^\/([^@\s]+)@?(?:(\S+)|)\s?([\s\S]*)$", RegexOptions.Compiled);

        private static string _botname = string.Empty;

        public string Command { get; set; }
        public string Botname { get; set; }
        public string Arguments { get; set; }

        public bool Is(string command)
        {
            if (string.IsNullOrEmpty(Botname))
            {
                return Command == command;
            }
            return _botname == Botname && command == Command;
        }

        public static void SetBotname(string botname) => _botname = botname;

        public static CommandMessage Parse(string input)
        {
            var m = _rg.Match(input);
            if (!m.Success)
                return new CommandMessage { Command = string.Empty, Botname = string.Empty, Arguments = string.Empty };
            return new CommandMessage
            {
                Command = m.Groups[1].Value.ToUpper(),
                Botname = m.Groups[2].Value.ToUpper(),
                Arguments = m.Groups[3].Value
            };
        }
    }
}
