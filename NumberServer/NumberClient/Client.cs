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
            // Creates a UdpClient for reading incoming data.
            UdpClient udpClient = new UdpClient(9999);

            // Localhost Ip
            // IPAddress ip = IPAddress.Parse("127.0.0.1");

            // Makes a endpoint, which ip and port the endpoint should listens to
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 9999);

            try
            {
                // writes the message Client
                Console.WriteLine("Client");

                //infinity loop
                while (true)
                {
                    // Gets the received data as Bytes from the endpoint
                    Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    //Writes the received data + ip adresse and port number
                    Console.WriteLine("server: " + receivedData);
                    Console.WriteLine("This message was sent from " +
                                                remoteIpEndPoint.Address.ToString() +
                                                " on their port number " +
                                                remoteIpEndPoint.Port.ToString() + "\n");

                   
                    Thread.Sleep(3000);  // Makes the program receive the data 500 milesecond later. 1000 = 1 second
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
