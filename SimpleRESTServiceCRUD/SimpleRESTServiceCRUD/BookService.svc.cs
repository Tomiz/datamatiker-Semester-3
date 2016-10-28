using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleRESTServiceCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        private static readonly IBookRepository Repository = new BookRepository();
        public List<Book> GetBookList()
        {
            return Repository.GetAllBooks();
        }

        public Book GetBookIdList(string id)
        {
            return Repository.GetBookId(int.Parse(id));
        }

        public string AddBook(Book book)
        {
            Book newBook = Repository.AddNewBook(book);
            return "id: " + newBook.BookId;
        }

        public string UpdateBook(Book book, string id)
        {
            bool updated = Repository.UpdateABook(book);
            if (updated)
            {
                return "Book with id: " + id + " updated successfully";
            }
            else
            {
                return "Unabl to update book with id: " + id;
            }
        }

        public string DeleteBook(string id)
        {
            bool deleted = Repository.DeleteABook(int.Parse(id));
            if (deleted)
            {
                return "Book with id: " + id + " deleted successfully";
            }
            else
            {
                return "unable to delete book with id: " + id;
            }
        }
    }
}
