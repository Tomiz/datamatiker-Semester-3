using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRESTServiceCRUD
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        private int counter = 1;

        public BookRepository()
        {
            AddNewBook(new Book { Title = "Thinking in C#", ISBN = "65674523432423" });
            AddNewBook(new Book { Title = "Thinking in Java", ISBN = "34223434543423" });
            AddNewBook(new Book { Title = "Beginning WCF", ISBN = "35343532423" });
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookId(int id)
        {
            return books.Find(b => b.BookId == id);
        }

        public Book AddNewBook(Book item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item)); item.BookId = counter++;
            books.Add(item);
            return item;
        }

        public bool DeleteABook(int id)
        {
            int idx = books.FindIndex(b => b.BookId == id);
            if (idx == -1)
                return false; books.RemoveAll(b => b.BookId == id);
            return true;
        }

        public bool UpdateABook(Book item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            int idx = books.FindIndex(b => b.BookId == item.BookId);
            if (idx == -1)
                return false; books.RemoveAt(idx);
            books.Add(item);
            return true;
        }
    }
}