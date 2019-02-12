using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using static System.Console;

namespace CI203_semester_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new BookContext())
            {
                Book book1 = new Book { Title = "Hamlet", Author = "Shakespeare" };
                Book book2 = new Book { Title = "Othello", Author = "Shakespeare" };
                db.Books.Add(book1);
                db.Books.Add(book2);
                db.SaveChanges();

                //LINQ query
                var query = from b in db.Books
                            orderby b.Title
                            select b;
                foreach(var r in query)
                {
                    WriteLine($"{r.Title} by {r.Author} code= {r.Code}");
                }
                WriteLine("Press any key to continue...");
                ReadKey();
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [Key] public int Code { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

}
