using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using SimpleRESTServiceCRUD;

namespace Consumer
{
    class Program
    {
        public static string Param { get; set; }
        
        static void Main(string[] args)
        {
            //while (Param != "x")
            //{
            //    Param = Console.ReadLine();
            //    //if (Param == "addbook")
            //    //{
            //    Task t2 = new Task(AddBookAsync);
            //    t2.Start();
            //    //}
            //    //Task t1 = new Task(GetBookAsync);
            //    //t1.Start();

            //    Console.WriteLine("Downloading page!");
            //}

            //Console.ReadLine();
            ////List<Book> books = new List<Book>();
            ////books = GetBookAsync();
            
            GetBook();
            Console.ReadKey();
        }

        private static async void GetBook()
        {
            const string serviceBookUri = "http://localhost:21936/BookService.svc/books/";

            HttpClient client = new HttpClient();
            string content = await client.GetStringAsync(serviceBookUri);

            List<Book> cList = JsonConvert.DeserializeObject<List<Book>>(content);
            cList.ForEach(Console.WriteLine);
        }

        private static async void GetBookAsync()
        {
            string bookServiceUri;
            if (Param == "all")
            {
                bookServiceUri = "http://localhost:21936/BookService.svc/books/";
            }
            else
            {
                bookServiceUri = "http://localhost:21936/BookService.svc/books/" + Param;
            }


            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(bookServiceUri);
                if (Param == "all")
                {
                    List<Book> cList = JsonConvert.DeserializeObject<List<Book>>(content);
                    cList.ForEach(Console.WriteLine);
                    foreach (var book in cList)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
        }

        private static void AddBookAsync()
        {
            throw new NotImplementedException();
        }
    }
}
