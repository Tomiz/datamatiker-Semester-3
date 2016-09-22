using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Teknik_mockExam_2016_09_21
{
    public class Program
    {
        static void Main(string[] args)
        {
            // IP address which the server uses, 127.0.0.1 is localhost, can be changed after need
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            try
            {
                // which IP and port the server should listen to
                TcpListener myServer = new TcpListener(ip, 80);
                //starter serveren
                myServer.Start();

                // runs a while loop
                while (true)
                {
                    TcpClient connectionSocket = myServer.AcceptTcpClient();
                    Console.WriteLine("Server started");
                    // uses the class EchoServer, which reads and writes the message
                    EchoService service = new EchoService(connectionSocket);
                    //service.Message();
                    service.Message();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
