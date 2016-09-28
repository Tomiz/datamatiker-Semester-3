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

            // Localhost Ip adress
            //IPAddress ip = IPAddress.Parse("127.0.0.1");

            // Creates a UdpClient for reading incoming data.
            UdpClient udpServer = new UdpClient(0);

            // Makes a endpoint, which ip and port the endpoint should broadcast
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 9999);
            udpServer.EnableBroadcast = true;

            try
            {
                // infinity loop
                while (true)
                {
                    // Sends the data as Bytes to the endpoint
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Thomas: " + number);

                    try
                    {
                        // Writes the data as Bytes and its lenght to the endpoint
                        udpServer.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);                          
                    }

                    number++; // counts + 1 for every time  it runs the loop
                    Console.WriteLine("number: " + number); // prints the current number

                    Thread.Sleep(400); // Makes the program receive the data 400 milesecond later. 1000 = 1 second

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
