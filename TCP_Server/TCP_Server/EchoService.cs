using System;
using System.IO;
using System.Net.Sockets;

namespace TCP_Server
{
    public class EchoService
    {
        private readonly TcpClient _connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            //TODO: Comåæete member initialization
            this._connectionSocket = connectionSocket;
        }

        internal void DoIt()
        {
            NetworkStream ns = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; //enable automatic flushing

            string message = sr.ReadLine();
            string answer;

            while (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }
            ns.Close();
            _connectionSocket.Close();
        }
    }
}