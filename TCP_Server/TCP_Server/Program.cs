using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAdrAddress = Dns.GetHostEntry("localhost").AddressList[0];
            try
            {
                TcpListener myServer = new TcpListener(ipAdrAddress, 6789);
                myServer.Start();
                TcpClient myServerTcpClientConnection = myServer.AcceptTcpClient();

                Console.WriteLine("Server started");

                Stream connectionStream = myServerTcpClientConnection.GetStream();

                StreamReader streamReader = new StreamReader(connectionStream);
                StreamWriter streamWriter = new StreamWriter(connectionStream);
                streamWriter.AutoFlush = true;

                string msg = streamReader.ReadLine();

                //Console.WriteLine(msg);

                //Console.WriteLine("Message recieved");
                //string rsp = streamReader.ReadLine();
                //streamWriter.WriteLine(rsp);

                while (!string.IsNullOrEmpty(msg) && msg != "stop")
                {
                    //streamWriter.WriteLine(msg.ToUpper());
                    //msg = streamReader.ReadLine();

                    Console.WriteLine(msg.ToUpper());

                    Console.WriteLine("Message recieved");
                    streamReader.ReadLine();

                    Console.ReadKey();
                    Console.WriteLine("Write!");

                    streamWriter.WriteLine(msg);
                    string rsp = streamReader.ReadLine();

                    Console.WriteLine(rsp);

                }

                //Console.ReadLine();

                //connectionStream.Close();
                //myServerTcpClientConnection.Close();
                //myServer.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
