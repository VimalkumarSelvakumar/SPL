using Gameleon.Modelsnamespace;
using Newtonsoft.Json;

namespace Gameleon.Models
{
    public class ResponseMessage : BaseMessage
    {
        [JsonProperty("move")]
        public string Move { get; set; }
    }
}
