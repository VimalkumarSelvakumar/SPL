using Newtonsoft.Json;

namespace Gameleon.Models
{
    public class BaseMessage
    {
        [JsonProperty("dataType")]
        public string DataType { get; set; } = string.Empty;
    }
}
