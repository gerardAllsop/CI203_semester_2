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
                Book book1 = new Book { Title = "Martin Chuzzlewit", Author = "Charles Dickens" };
                Book book2 = new Book { Title = "London Fields", Author = "Martin Amis" };

                var testQuery = from b in db.Books
                                where b.Title == book1.Title && b.Author == book1.Author
                                select b;
                if(testQuery.Count() < 1) { db.Books.Add(book1); }

                testQuery = from b in db.Books
                                where b.Title == book2.Title && b.Author == book2.Author
                                select b;
                if (testQuery.Count() < 1) { db.Books.Add(book2); }
                db.Books.Add(book2);

                db.SaveChanges();

                var store1 = new Store
                {
                    Name = "Brighton Campus Books",
                    Address = "Brighton",
                    Inventory = new List<Stock>()
                };

                var store2 = new Store
                {
                    Name = "Hastings Campus Books",
                    Address = "Hastings",
                    Inventory = new List<Stock>()
                };

                
                db.Stores.Add(store1);
                Stock store1book1 = new Stock { Item = book1, OnHand = 4, OnOrder = 6 };
                //Needs check for duplicate store
                store1.Inventory.Add(store1book1);
               
                db.Stores.Add(store2);
                Stock store2book1  = new Stock { Item = book1, OnHand = 2, OnOrder = 9 };
                //Needs check for duplicate store
                store2.Inventory.Add(store2book1);

                db.SaveChanges();

                var query = from store in db.Stores
                            orderby store.Name
                            select store;

                WriteLine("BookStore Inventory Report: ");
                foreach(var store in query)
                {
                    WriteLine($"{store.Name} located at {store.Address}");
                    foreach(var stock in store.Inventory) {
                        WriteLine($"- Title: {stock.Item.Title}");
                        WriteLine($"-- Copies in Store: {stock.OnHand}");
                        WriteLine($"-- Copies on Order: {stock.OnOrder}");
                    }
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

    public class Store
    {
        [Key] public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Stock> Inventory { get; set; }
    }

    public class Stock
    {
        [Key] public int StockId { get; set; }
        public int OnHand { get; set; }
        public int OnOrder { get; set;}
        public virtual Book Item { get; set; }
    }


    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}

