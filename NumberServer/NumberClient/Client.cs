using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberClient
{
    class Client
    {
        static void Main(string[] args)
        {
            //Creates a UdpClient for reading incoming data.
            UdpClient udpClient = new UdpClient(9999);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ip = IPAddress.Parse("192.168.3.205");

            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 9999);
            //udpClient.EnableBroadcast = true;

            try
            {
                // Blocks until a message is received on this socket from a remote host (a client).
                Console.WriteLine("Client is blocked");
                while (true)
                {
                    Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine("server: " + receivedData);
                    //Console.WriteLine("Received from: " + clientName.ToString() + " " + text.ToString());

                    Console.WriteLine("This message was sent from " +
                                                remoteIpEndPoint.Address.ToString() +
                                                " on their port number " +
                                                remoteIpEndPoint.Port.ToString() + "\n");
                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
