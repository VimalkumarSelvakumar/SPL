﻿using Gameleon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Gameleon
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 2024);

            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(localEndPoint);

            Console.WriteLine("Socket connected to -> {0} ", sender.RemoteEndPoint.ToString());

            while (true)
            {

                var encodedString = GetResponce(sender);
                var baseMessage = GameMessageParser.Parse(encodedString);

            }
        }



        private static string GetResponce(Socket sender)
        {
            byte[] length = new byte[4];
            int byteRecv = sender.Receive(length);
            byte[] lengthBytes = length.Take(4).ToArray();
            int lengthOfMessage = BytesToInt(lengthBytes);
            byte[] messageReceived = new byte[lengthOfMessage];
            int messageRecv = sender.Receive(messageReceived);
            string encodedString = Encoding.ASCII.GetString(messageReceived.ToArray());
            return encodedString;
        }

        public static int BytesToInt(byte[] bytes)
        {
            if (bytes.Length != 4)
                throw new ArgumentException("Byte array must be exactly 4 bytes long.");

            return (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3];
        }
        public static byte[] JsonToByteArray(byte[] jsonBytes)
        {
            int length = jsonBytes.Length;
            byte[] result = new byte[4 + length];

            // Length prefix in big-endian (network byte order)
            result[0] = (byte)((length >> 24) & 0xFF);
            result[1] = (byte)((length >> 16) & 0xFF);
            result[2] = (byte)((length >> 8) & 0xFF);
            result[3] = (byte)(length & 0xFF);

            // Copy JSON bytes after the length prefix
            Buffer.BlockCopy(jsonBytes, 0, result, 4, length);

            return result;
        }
    }
}
