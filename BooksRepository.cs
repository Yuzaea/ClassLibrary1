using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   
    public class BooksRepository
    {
        private List<Book> books;
        public BooksRepository() {

            books = new List<Book>
            {
                new Book(1,200, "poe poem collection"),
                new Book(2,300, "Tale of gilgamesh"),
                new Book(3,400, "Iliad"),
             new Book(4,500, "Odyssey"),
                new Book(5,600, "Virgil")
            };


           



        
        }

        public Book Add(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            int newID = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            book.Id= newID;

            books.Add(book);

            return book;
        }


        public Book GetBookByID(int id)
        {
            foreach (var book in books)
            {
                if(book.Id == id) return book;
            }
            return null;
        }



        public Book Delete(int id)
        {
            Book booktodelete = null;
            foreach (var book in books)
            {
                if (book.Id == id)
                    booktodelete = book;
                books.Remove(booktodelete);
            }
            return booktodelete;
        }

        public List<Book> Get(Func<Book, bool> filter = null, string sortBy = null)
        {
            var booksresults = new List<Book>(books);

            if (filter != null)
            {
                booksresults = booksresults.Where(filter).ToList();
            }


            if(!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    booksresults = booksresults.OrderBy(book => book.Title).ToList();
                }
                else if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    booksresults = booksresults.OrderBy(book => book.Price).ToList();
                }
            }
            return booksresults;
        }

    }
}
