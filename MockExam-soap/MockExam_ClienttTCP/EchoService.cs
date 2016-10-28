using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockExam_ServerTCP
{
    public class EchoService
    {
        private readonly TcpClient _connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            _connectionSocket = connectionSocket;
        }

        internal void DoIt()
        {
            NetworkStream ns = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; //enable automatic flushing

            string message = sr.ReadLine();
            string answer;

            while (true)
            {
                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
                if (message == "stop".ToUpper())
                {
                    Console.WriteLine("server stopped");
                    break;
                }
            }
            ns.Close();
            _connectionSocket.Close();
        }
    }
}
