using Gameleon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameleon
{
    public class SendMessageData
    {
        public static byte[] Parse(SendMessage message)
        {
            string json = JsonConvert.SerializeObject(message);

            // Convert to UTF-8 bytes
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            int length = jsonBytes.Length;

            // Prepare final buffer: 4 bytes length + json data
            byte[] result = new byte[4 + length];

            // Store length in first 4 bytes (big-endian)
            result[0] = (byte)(length >> 24);
            result[1] = (byte)(length >> 16);
            result[2] = (byte)(length >> 8);
            result[3] = (byte)(length);

            Array.Copy(jsonBytes, 0, result, 4, length);

            return result;
        }
    }
}
