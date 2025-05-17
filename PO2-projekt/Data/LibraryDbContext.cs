using Microsoft.EntityFrameworkCore;
using PO2_projekt.Models;
using System;

namespace PO2_projekt.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // SEED: Kategorie
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Poezja" },
                new Category { Id = 2, Name = "Powieść" },
                new Category { Id = 3, Name = "Fantastyka" }
            );

            // SEED: Autorzy
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Adam", LastName = "Mickiewicz" },
                new Author { Id = 2, FirstName = "Henryk", LastName = "Sienkiewicz" }
            );

            // SEED: Książki
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Pan Tadeusz", YearPublished = 1834, Copies = 5, CategoryId = 1 },
                new Book { Id = 2, Title = "Quo Vadis", YearPublished = 1896, Copies = 3, CategoryId = 2 }
            );

            // SEED: Relacja BookAuthor
            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { BookId = 1, AuthorId = 1 },
                new BookAuthor { BookId = 2, AuthorId = 2 }
            );

            // SEED: Czytelnicy
            modelBuilder.Entity<Reader>().HasData(
                new Reader { Id = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jan.kowalski@example.com", Country = "Polska", CreateAt = new DateTime(2023,1,1) },
                new Reader { Id = 2, FirstName = "Anna", LastName = "Nowak", Email = "anna.nowak@example.com", Country = "Polska", CreateAt = new DateTime(2023,2,1) }
            );

            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}