using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }

        public override string ToString()
        {
            return $"{nameof(BookId)}: {BookId}, {nameof(Title)}: {Title}, {nameof(ISBN)}: {ISBN}";
        }
    }
}
