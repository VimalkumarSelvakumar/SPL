using Newtonsoft.Json;

namespace Gameleon.Modelsnamespace
{
    public class BaseMessage
    {
        [JsonProperty("dataType")]
        public string DataType { get; set; } = string.Empty;
    }
}
