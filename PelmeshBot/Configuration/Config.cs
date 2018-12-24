using Newtonsoft.Json;

namespace PelmeshBot.Configuration
{
    public class Config
    {
        [JsonProperty("telegram_api_key")]
        public string TelegramApiKey { get; set; }

        [JsonProperty("bot_name")]
        public string BotName { get; set; }
    }
}
