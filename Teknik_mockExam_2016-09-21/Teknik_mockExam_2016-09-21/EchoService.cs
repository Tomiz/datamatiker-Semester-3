using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_mockExam_2016_09_21
{
    public class EchoService
    {
        private readonly TcpClient _connectionSocket;

        /// <summary>
        /// The path to the file, the path can be changed after need
        /// </summary>
        private static readonly string RootCatalog =
            @"C:\Users\thoma\Source\Repos\datamatiker-semester-3\Teknik_mockExam_2016-09-21\Teknik_mockExam_2016-09-21\rootCatalog\";

        public EchoService(TcpClient connectionSocket)
        {
            _connectionSocket = connectionSocket;
        }

        /// <summary>
        /// uses the path from RootCatalog og splits it up and returns the path
        /// it used in the method Message()
        /// </summary>
        /// <returns></returns>
        private static string Root()
        {
            string dir = RootCatalog;
            string[] parts = dir.Split('\\');

            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
            return dir;
        }

        /// <summary>
        /// This method open and closes streams.
        /// its making a HTTP GET response to the browser and gives the browers the file which it opens and reads
        /// afterward it closes the connection, and the brower get its response and shows the file
        /// </summary>
        internal void Message()
        {
            using (_connectionSocket)
            {
                try
                {
                    Stream cs = _connectionSocket.GetStream();

                    StreamReader sr = new StreamReader(cs);
                    StreamWriter sw = new StreamWriter(cs) {AutoFlush = true}; // enable automatic flushing

                    string message = " ";

                    while (message != null && message.ToLower() != "stop")
                    {
                        message = sr.ReadLine();

                        Console.WriteLine(message);

                        // Makes a request on the browser request
                        // if the message contains something which is not null, and the message contains a GET and http 1.1 request, it does something
                        if (message != null && (message.Contains("GET") && message.Contains("HTTP/1.1")))
                        {
                            try
                            {
                                // The file which it should open
                                message = File.ReadAllText(Root() + @"testfil.txt");
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }
                            sw.WriteLine(message.ToLower());
                        }
                        else
                        {
                            if (message != null) sw.WriteLine(message.ToLower());
                        }

                        // Closes the connection to the server
                        cs.Close();
                        _connectionSocket.Close();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
