using Newtonsoft.Json;

namespace Gameleon.Models
{
    public class ResultMessage : BaseMessage
    {
        [JsonProperty("gameResult")]
        public string GameResult { get; set; }
    }
}
