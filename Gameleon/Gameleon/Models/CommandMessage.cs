using Gameleon.Modelsnamespace;
using Newtonsoft.Json;

namespace Gameleon.Models
{
    public class CommandMessage : BaseMessage
    {
        [JsonProperty("boardSize")]
        public string BoardSize { get; set; }

        [JsonProperty("boardStatus")]
        public string BoardStatus { get; set; }

        [JsonProperty("errCount")]
        public int ErrCount { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("p1Points")]
        public int P1Points { get; set; }

        [JsonProperty("p2Points")]
        public int P2Points { get; set; }

        [JsonProperty("possibleMoves")]
        public string PossibleMoves { get; set; }

        [JsonProperty("misc")]
        public string Misc { get; set; }
    }

}
