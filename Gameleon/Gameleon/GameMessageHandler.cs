using Gameleon.Models;
using Newtonsoft.Json;
using System;

public class GameMessageHandler
{
    public void HandleMessage(string json)
    {
        var baseMessage = JsonConvert.DeserializeObject<BaseMessage>(json);

        switch (baseMessage.DataType)
        {
            case "command":
                var command = JsonConvert.DeserializeObject<CommandMessage>(json);
                HandleCommand(command);
                break;

            case "response":
                var response = JsonConvert.DeserializeObject<ResponseMessage>(json);
                HandleResponse(response);
                break;

            case "acknowledge":
                var ack = JsonConvert.DeserializeObject<AcknowledgeMessage>(json);
                HandleAcknowledge(ack);
                break;

            case "result":
                var result = JsonConvert.DeserializeObject<ResultMessage>(json);
                HandleResult(result);
                break;

            default:
                Console.WriteLine("Unknown dataType");
                break;
        }
    }

    private void HandleCommand(CommandMessage command)
    {
        string[] possibleMoves = command.PossibleMoves.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        string move = possibleMoves.Length > 0 ? possibleMoves[0] : "-1";

        var response = new ResponseMessage
        {
            DataType = "response",
            Move = move
        };

        string jsonResponse = JsonConvert.SerializeObject(response);
        Console.WriteLine("Responding with: " + jsonResponse);
        // Send this jsonResponse to the game server
    }

    private void HandleResponse(ResponseMessage response)
    {
        Console.WriteLine("Move made: " + response.Move);
    }

    private void HandleAcknowledge(AcknowledgeMessage ack)
    {
        Console.WriteLine($"Acknowledged: {ack.Acknowledge} - Reason: {ack.Reason}");
    }

    private void HandleResult(ResultMessage result)
    {
        Console.WriteLine("Game Result: " + result.GameResult);
    }
}
