using Newtonsoft.Json;

namespace Gameleon.Models
{
    public class AcknowledgeMessage : BaseMessage
    {
        [JsonProperty("acknowledge")]
        public string Acknowledge { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("misc")]
        public string Misc { get; set; }

    }
}
