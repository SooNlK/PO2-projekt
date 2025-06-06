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

            // SEED: Kategorie (40 rzeczywistych)
            var categoryNames = new[] {
                "Powieść", "Kryminał", "Fantastyka", "Biografia", "Poezja", "Dramat", "Horror", "Romans", "Przygodowa", "Nauka",
                "Esej", "Reportaż", "Literatura dziecięca", "Literatura młodzieżowa", "Publicystyka", "Satyra", "Literatura faktu", "Historyczna", "Obyczajowa", "Psychologiczna",
                "Filozofia", "Religia", "Podróżnicza", "Sensacja", "Thriller", "Science fiction", "Fantasy", "Komiks", "Literatura piękna", "Literatura współczesna", "Literatura klasyczna",
                "Antologia", "Opowiadania", "Nowela", "Literatura kobieca", "Poradnik", "Motywacyjna", "Ekonomia", "Biznes", "Technologia", "Sztuka"
            };
            var categories = new Category[40];
            for (int i = 0; i < 40; i++)
                categories[i] = new Category { Id = i + 1, Name = categoryNames[i] };
            modelBuilder.Entity<Category>().HasData(categories);

            // SEED: Autorzy (40 rzeczywistych)
            var authorList = new[] {
                ("Adam", "Mickiewicz"), ("Henryk", "Sienkiewicz"), ("Olga", "Tokarczuk"), ("Stephen", "King"), ("J.K.", "Rowling"),
                ("Stanisław", "Lem"), ("J.R.R.", "Tolkien"), ("Andrzej", "Sapkowski"), ("Agatha", "Christie"), ("Haruki", "Murakami"),
                ("Dan", "Brown"), ("Eliza", "Orzeszkowa"), ("Bolesław", "Prus"), ("George", "Orwell"), ("Jo Nesbø", ""),
                ("Fiodor", "Dostojewski"), ("Gabriel", "García Márquez"), ("Umberto", "Eco"), ("Margaret", "Atwood"), ("C.S.", "Lewis"),
                ("Ernest", "Hemingway"), ("William", "Shakespeare"), ("Charles", "Dickens"), ("Jane", "Austen"), ("Emily", "Brontë"),
                ("Mark", "Twain"), ("Franz", "Kafka"), ("Antoine", "de Saint-Exupéry"), ("Jules", "Verne"), ("Isaac", "Asimov"),
                ("Terry", "Pratchett"), ("Michael", "Ende"), ("Astrid", "Lindgren"), ("Lewis", "Carroll"), ("Harlan", "Coben"),
                ("Mario", "Puzo"), ("Carlos", "Ruiz Zafón"), ("Patrick", "Süskind"), ("Khaled", "Hosseini"), ("Harper", "Lee"), ("E.L.", "James")
            };
            var authors = new Author[40];
            for (int i = 0; i < 40; i++)
                authors[i] = new Author { Id = i + 1, FirstName = authorList[i].Item1, LastName = authorList[i].Item2 };
            modelBuilder.Entity<Author>().HasData(authors);

            // SEED: Książki (40 rzeczywistych)
            var bookList = new[] {
                ("Pan Tadeusz", 1834, 1), ("Quo Vadis", 1896, 1), ("Bieguni", 2007, 3), ("Lśnienie", 1977, 7), ("Harry Potter i Kamień Filozoficzny", 1997, 3),
                ("Solaris", 1961, 3), ("Władca Pierścieni", 1954, 26), ("Krew elfów", 1994, 26), ("Morderstwo w Orient Expressie", 1934, 2), ("Norwegian Wood", 1987, 10),
                ("Kod Leonarda da Vinci", 2003, 5), ("Nad Niemnem", 1888, 1), ("Lalka", 1890, 1), ("Rok 1984", 1949, 6), ("Człowiek nietoperz", 1997, 2),
                ("Sto lat samotności", 1967, 18), ("Imię róży", 1980, 2), ("Opowieść podręcznej", 1985, 19), ("Lew, czarownica i stara szafa", 1950, 26), ("Stary człowiek i morze", 1952, 20),
                ("Romeo i Julia", 1597, 6), ("Wielkie nadzieje", 1861, 29), ("Duma i uprzedzenie", 1813, 8), ("Wichrowe wzgórza", 1847, 8), ("Przygody Tomka Sawyera", 1876, 9),
                ("Proces", 1925, 8), ("Mały Książę", 1943, 13), ("W 80 dni dookoła świata", 1873, 9), ("Fundacja", 1951, 25), ("Kolor magii", 1983, 26),
                ("Momo", 1973, 13), ("Dzieci z Bullerbyn", 1947, 13), ("Alicja w Krainie Czarów", 1865, 13), ("Nie mów nikomu", 2001, 24), ("Ojciec chrzestny", 1969, 9),
                ("Cień wiatru", 2001, 29), ("Pachnidło", 1985, 8), ("Chłopiec z latawcem", 2003, 9), ("Zabić drozda", 1960, 8), ("Pięćdziesiąt twarzy Greya", 2011, 8)
            };
            var books = new Book[40];
            for (int i = 0; i < 40; i++)
                books[i] = new Book { Id = i + 1, Title = bookList[i].Item1, YearPublished = bookList[i].Item2, Copies = 5 + (i % 3), CategoryId = bookList[i].Item3 };
            modelBuilder.Entity<Book>().HasData(books);

            // SEED: Czytelnicy (40 rzeczywistych)
            var readerList = new[] {
                ("Jan", "Kowalski", "jan.kowalski@example.com"), ("Anna", "Nowak", "anna.nowak@example.com"), ("Piotr", "Zieliński", "piotr.zielinski@example.com"), ("Maria", "Wiśniewska", "maria.wisniewska@example.com"),
                ("Krzysztof", "Wójcik", "krzysztof.wojcik@example.com"), ("Agnieszka", "Krawczyk", "agnieszka.krawczyk@example.com"), ("Tomasz", "Mazur", "tomasz.mazur@example.com"), ("Katarzyna", "Dąbrowska", "katarzyna.dabrowska@example.com"),
                ("Michał", "Lewandowski", "michal.lewandowski@example.com"), ("Barbara", "Zając", "barbara.zajac@example.com"), ("Paweł", "Król", "pawel.krol@example.com"), ("Ewa", "Wieczorek", "ewa.wieczorek@example.com"),
                ("Andrzej", "Jankowski", "andrzej.jankowski@example.com"), ("Magdalena", "Witkowska", "magdalena.witkowska@example.com"), ("Marek", "Kowalczyk", "marek.kowalczyk@example.com"), ("Joanna", "Szymańska", "joanna.szymanska@example.com"),
                ("Grzegorz", "Woźniak", "grzegorz.wozniak@example.com"), ("Aleksandra", "Kozłowska", "aleksandra.kozlowska@example.com"), ("Łukasz", "Jabłoński", "lukasz.jablonski@example.com"), ("Monika", "Pawlak", "monika.pawlak@example.com"),
                ("Natalia", "Sikora", "natalia.sikora@example.com"), ("Rafał", "Baran", "rafal.baran@example.com"), ("Karolina", "Sadowska", "karolina.sadowska@example.com"), ("Dariusz", "Górski", "dariusz.gorski@example.com"),
                ("Patrycja", "Czarnecka", "patrycja.czarnecka@example.com"), ("Wojciech", "Kaczmarek", "wojciech.kaczmarek@example.com"), ("Sylwia", "Piotrowska", "sylwia.piotrowska@example.com"), ("Mariusz", "Adamski", "mariusz.adamski@example.com"),
                ("Izabela", "Wróbel", "izabela.wrobel@example.com"), ("Sebastian", "Lis", "sebastian.lis@example.com"), ("Beata", "Michalska", "beata.michalska@example.com"), ("Adrian", "Kubiak", "adrian.kubiak@example.com"),
                ("Wiktoria", "Duda", "wiktoria.duda@example.com"), ("Szymon", "Bąk", "szymon.bak@example.com"), ("Emilia", "Jaworska", "emilia.jaworska@example.com"), ("Mateusz", "Walczak", "mateusz.walczak@example.com"),
                ("Julia", "Szymańska", "julia.szymanska@example.com"), ("Artur", "Pawłowski", "artur.pawlowski@example.com"), ("Paulina", "Witkowska", "paulina.witkowska@example.com"), ("Kamil", "Rutkowski", "kamil.rutkowski@example.com"),
                ("Marta", "Ostrowska", "marta.ostrowska@example.com"), ("Tadeusz", "Sikorski", "tadeusz.sikorski@example.com")
            };
            var readers = new Reader[40];
            for (int i = 0; i < 40; i++)
                readers[i] = new Reader { Id = i + 1, FirstName = readerList[i].Item1, LastName = readerList[i].Item2, Email = readerList[i].Item3, Country = "Polska", CreateAt = DateTime.SpecifyKind(new DateTime(2023, 1, 1).AddDays(i), DateTimeKind.Utc) };
            modelBuilder.Entity<Reader>().HasData(readers);

            // SEED: BookAuthor (każda książka ma jednego autora z pierwszych 40)
            var bookAuthors = new BookAuthor[40];
            for (int i = 0; i < 40; i++)
                bookAuthors[i] = new BookAuthor { BookId = i + 1, AuthorId = ((i % 40) + 1) };
            modelBuilder.Entity<BookAuthor>().HasData(bookAuthors);

            // SEED: Wypożyczenia (każda książka wypożyczona przez innego czytelnika)
            var borrowings = new Borrowing[40];
            for (int i = 0; i < 40; i++)
                borrowings[i] = new Borrowing { Id = i + 1, BookId = ((i % 40) + 1), UserId = ((i % 40) + 1), BorrowDate = DateTime.SpecifyKind(new DateTime(2024, 1, 1).AddDays(i), DateTimeKind.Utc), ReturnDate = null, Returned = false };
            modelBuilder.Entity<Borrowing>().HasData(borrowings);

            // SEED: Rezerwacje (każda książka zarezerwowana przez innego czytelnika)
            var reservations = new Reservation[40];
            for (int i = 0; i < 40; i++)
                reservations[i] = new Reservation { Id = i + 1, BookId = ((i % 40) + 1), UserId = ((i % 40) + 1), ReservedAt = DateTime.SpecifyKind(new DateTime(2024, 2, 1).AddDays(i), DateTimeKind.Utc), Expiration = DateTime.SpecifyKind(new DateTime(2024, 3, 1).AddDays(i), DateTimeKind.Utc) };
            modelBuilder.Entity<Reservation>().HasData(reservations);

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