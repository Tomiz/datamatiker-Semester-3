using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberServer
{
    class Server
    {
        static void Main(string[] args)
        {
            int number = 0;

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            //IPAddress ip = IPAddress.Parse("127.0.0.1");

            //Creates a UdpClient for reading incoming data.
            UdpClient udpServer = new UdpClient(0);
            //UdpClient udpServer = new UdpClient("127.0.0.1", 9999);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 9999);
            udpServer.EnableBroadcast = true;

            try
            {
                while (true)
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Thomas: " + number);

                    try
                    {
                        udpServer.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);                          
                    }

                    number++;
                    Console.WriteLine("number: " + number);

                    Thread.Sleep(400);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
