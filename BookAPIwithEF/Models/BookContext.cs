using Microsoft.Data.SqlClient;
using System;
using Microsoft.EntityFrameworkCore;


namespace BookAPIwithEF.Models
{
    public class BookContext : DbContext
    {
        public BookContext()
        {

        }

        public DbSet<Book> Books { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FERDIE\\SQLEXPRESS;Database=assignment;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }

}

