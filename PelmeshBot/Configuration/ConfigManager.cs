using Newtonsoft.Json;
using System.IO;

namespace PelmeshBot.Configuration
{
    public static class ConfigManager
    {
        public static Config LoadConfig(string filename) =>
            JsonConvert.DeserializeObject<Config>(File.ReadAllText(filename));
    }
}
