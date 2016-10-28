using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MockExam_ClientTCP.ServiceReference1;

namespace MockExam_ClientTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press enter to make connection to the server");
            Console.ReadKey();

            TcpClient myTcpClientConnection = new TcpClient("192.168.3.73", 6789);

            Stream connectionStream = myTcpClientConnection.GetStream();

            while (true)
            {
                StreamReader streamReader = new StreamReader(connectionStream);
                StreamWriter streamWriter = new StreamWriter(connectionStream);
                streamWriter.AutoFlush = true;

                Console.WriteLine("tryk f for at konvertere Fehrenheit til celcius eller tryk c for at konvertere celcius til fehrenheit");
                ConsoleKeyInfo result = Console.ReadKey();
                if ((result.KeyChar == 'f') || (result.KeyChar == 'F'))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(getCelcius());
                }
                else if ((result.KeyChar == 'c') || (result.KeyChar == 'C'))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(getFehrenheit());
                }

                string msg = Console.ReadLine();
                streamWriter.WriteLine(msg);
                string rsp = streamReader.ReadLine();

                Console.WriteLine(rsp);
            }
        }

        static string getFehrenheit()
        {
            string text = "enter a celcius tempature";
            // Laver en reference til wcf Soap servicen så man kan bruge den
            ServiceReference1.Service1Client celcius = new Service1Client("BasicHttpBinding_IService1");

            // laver en variable ddouble, og bruger wcf soap servicen og gettemparture til at hente og konvertere cel til fehr
            double c = celcius.Celcius(GetTempature(text));
            //Udskriver reusltat
            return "The tempature in fehrenheit is: " + c;
        }

        static string getCelcius()
        {
            string text = "enter a Fehrenheit tempature";
            // Laver en reference til wcf Soap servicen så man kan bruge den
            ServiceReference1.Service1Client fehrenheit = new Service1Client("BasicHttpBinding_IService1");

            // laver en variable ddouble, og bruger wcf soap servicen og gettemparture til at hente og konvertere cel til fehr
            double f = fehrenheit.Fehrenheit(GetTempature(text));
            //Udskriver reusltat

            return "The tempature in celcius is: " + f;
        }

        /// <summary>
        /// returnere værdien man skriver
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static double GetTempature(string text)
        {
            Console.WriteLine(text);
            bool IsItTemp = false;
            double x = 0;

            do
            {
                IsItTemp = double.TryParse(Console.ReadLine(), out x);
            } while (!IsItTemp);

            return x;

        }
    }
}
