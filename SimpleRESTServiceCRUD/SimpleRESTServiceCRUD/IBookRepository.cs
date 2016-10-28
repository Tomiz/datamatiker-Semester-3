using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRESTServiceCRUD
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookId(int id);
        Book AddNewBook(Book item);
        bool DeleteABook(int id);
        bool UpdateABook(Book item);
    }
}