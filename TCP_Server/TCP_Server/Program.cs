using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ip adresse den connecter til
            IPAddress ip = IPAddress.Parse("192.168.3.252");
            //IPAddress ipAdrAddress = Dns.GetHostEntry("localhost").AddressList[0];
            try
            {
                //Hvilken Ip og port den skal listen til
                TcpListener myServer = new TcpListener(ip, 6789);
                //starter serveren
                myServer.Start();

                //Kører et while loop
                while (true)
                {
                    TcpClient connectionSocket = myServer.AcceptTcpClient();
                    Console.WriteLine("Server started");
                    //bruger classen EchoService, som reader og skriver beskeder 
                    EchoService service = new EchoService(connectionSocket);
                    Thread myThread = new Thread(service.DoIt);
                    myThread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
