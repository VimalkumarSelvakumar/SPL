using Gameleon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameleon
{
    public static class GameMessageParser
    {
        public static object Parse(string json)
        {
            var baseMessage = JsonConvert.DeserializeObject<BaseMessage>(json);

            switch (baseMessage.DataType)
            {
                case "command":
                    return JsonConvert.DeserializeObject<CommandMessage>(json);

                case "response":
                    return JsonConvert.DeserializeObject<ResponseMessage>(json);

                case "acknowledge":
                    return JsonConvert.DeserializeObject<AcknowledgeMessage>(json);

                case "result":
                    return JsonConvert.DeserializeObject<ResultMessage>(json);

                default:
                    throw new JsonException("Unknown dataType: " + baseMessage.DataType);
            }
        }

        public static CommandMessage ParseCommand(string json)
            => JsonConvert.DeserializeObject<CommandMessage>(json);

        public static ResponseMessage ParseResponse(string json)
            => JsonConvert.DeserializeObject<ResponseMessage>(json);

        public static AcknowledgeMessage ParseAcknowledge(string json)
            => JsonConvert.DeserializeObject<AcknowledgeMessage>(json);

        public static ResultMessage ParseResult(string json)
            => JsonConvert.DeserializeObject<ResultMessage>(json);
    }

}
