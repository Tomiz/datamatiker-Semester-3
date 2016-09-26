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

        private Stream _cs;
        private StreamReader _sr;
        private StreamWriter _sw;

        /// <summary>
        /// The path to the file, the path can be changed after need
        /// </summary>
        private static readonly string RootCatalog =@"C:\Users\thoma\Desktop\";

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
                    _cs = _connectionSocket.GetStream(); // Makes the GET Request and http/1.1

                    _sr = new StreamReader(_cs);
                    _sw = new StreamWriter(_cs) {AutoFlush = true}; // enable automatic flushing

                    string request = " ";
                    while (request != null && request.ToLower() != "stop")
                    {
                        request = _sr.ReadLine();

                        Console.WriteLine(request);

                        // Makes a request on the browser request
                        // if the message contains something which is not null, and the message contains a GET and http 1.1 request, it does something
                        if (request != null && (request.Contains("GET") && request.Contains("HTTP/1.1")))
                        {
                            try
                            {
                                // The file which it should open
                                request = File.ReadAllText(Root() + @"index.html");
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }
                            _sw.WriteLine(request.ToLower());
                        }
                        else
                        {
                            if (request != null) _sw.WriteLine(request.ToLower());
                        }

                        // Closes the connection to the server
                        _cs.Close();
                        _connectionSocket.Close();
                        Console.ReadKey();
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
