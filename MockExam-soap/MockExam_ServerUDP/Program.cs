using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockExam_ServerUDP
{
    public class Program
    {
        // !!!! ikke færdig
        static void Main(string[] args)
        {
            //Creates a UdpClient for reading incoming data.
            UdpClient udpServer = new UdpClient(9999);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPAddress ip = IPAddress.Parse("192.168.3.73");
            IPEndPoint remoteIpEndPoint = new IPEndPoint(ip, 9999);

            try
            {
                // Blocks until a message is received on this socket from a remote host (a client).
                Console.WriteLine("Server is on standby");
                while (true)
                {
                    Byte[] receiveBytes = udpServer.Receive(ref remoteIpEndPoint);
                    //Server is now activated");

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    string[] data = receivedData.Split(' ');
                    string clientName = data[0];
                    string text = data[1] + data[2];

                    Console.WriteLine(receivedData);
                    //Console.WriteLine("Received from: " + clientName.ToString() + " " + text.ToString());

                    string sendData = "Server: " + text.ToUpper();
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(sendData);

                    udpServer.Send(sendBytes, sendBytes.Length, remoteIpEndPoint);

                    Console.WriteLine("This message was sent from " +
                                                remoteIpEndPoint.Address.ToString() +
                                                " on their port number " +
                                                remoteIpEndPoint.Port.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
