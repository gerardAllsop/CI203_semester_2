﻿using System;
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

                var store1 = new Store
                {
                    Name = "Brighton Campus Books",
                    Address = "Brighton",
                    Inventory = new List<Stock>()
                };

                db.Stores.Add(store1);
                Stock store1book1 = new Stock { Item = book1, OnHand = 4, OnOrder = 6 };
                store1.Inventory.Add(store1book1);
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
