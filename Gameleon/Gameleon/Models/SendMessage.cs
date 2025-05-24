using Newtonsoft.Json;

namespace Gameleon.Models
{
    public class SendMessage
    {
        [JsonProperty("dataType")]
        public string DataType { get; set; } = string.Empty;

        [JsonProperty("move")]
        public string Move { get; set; }
    }
}
