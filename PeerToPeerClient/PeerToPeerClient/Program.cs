using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PeerToPeerClient
{
    class Program
    {
        //client
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("That program can transfer small file. I've test up to 850kb file // client");
                Console.ReadKey();
                IPAddress[] ipAddress = Dns.GetHostAddresses("localhost");
                IPEndPoint ipEnd = new IPEndPoint(ipAddress[0], 5656);
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                clientSock.Connect(ipEnd);

                byte[] clientData = new byte[1024 * 5000];

                string receivedPath = @"C:\Users\thoma\Desktop\test2";
                int receivedBytesLen = clientSock.Receive(clientData);
                int fileNameLen = BitConverter.ToInt32(clientData, 0);
                string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);

                Console.WriteLine($"Client:{clientSock.RemoteEndPoint} connected & File {fileName} started received.");

                BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append)); ;
                bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);

                Console.WriteLine($"File: {fileName} received & saved at path: {receivedPath}");

                bWrite.Close();
                clientSock.Close();
                Console.ReadLine();
                Console.WriteLine(Console.ReadKey());
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Sending fail." + ex.Message);
            }
        }
    }
}
