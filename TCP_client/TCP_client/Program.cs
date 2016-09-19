using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press enter to make connection to the server");
            Console.ReadKey();

            //TcpClient myTcpClientConnection = new TcpClient("192.168.3.252", 6789);
            //TcpClient myTcpClientConnection = new TcpClient("192.168.3.65", 8679);
            //TcpClient myTcpClientConnection = new TcpClient("192.168.3.249", 6789);
            TcpClient myTcpClientConnection = new TcpClient("192.168.3.27", 6789);
            //TcpClient myTcpClientConnection = new TcpClient("192.168.3.16", 6789);

            Stream connectionStream = myTcpClientConnection.GetStream();

            //string Rmsg = streamReader.ReadLine();

            while (true)
            {
                StreamReader streamReader = new StreamReader(connectionStream);
                StreamWriter streamWriter = new StreamWriter(connectionStream);
                streamWriter.AutoFlush = true;

                Console.WriteLine("Write your message");
                string msg = Console.ReadLine();
                streamWriter.WriteLine(msg);
                string rsp = streamReader.ReadLine();

                Console.WriteLine(rsp);

            }
            //while (!string.IsNullOrEmpty(msg) && msg != "stop")
            //{

            //}
        }

    }
}
