using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PO2projekt.Migrations
{
    /// <inheritdoc />
    public partial class Seed50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, "Olga", "Tokarczuk" },
                    { 4, "Stephen", "King" },
                    { 5, "J.K.", "Rowling" },
                    { 6, "Stanisław", "Lem" },
                    { 7, "J.R.R.", "Tolkien" },
                    { 8, "Andrzej", "Sapkowski" },
                    { 9, "Agatha", "Christie" },
                    { 10, "Haruki", "Murakami" },
                    { 11, "Dan", "Brown" },
                    { 12, "Eliza", "Orzeszkowa" },
                    { 13, "Bolesław", "Prus" },
                    { 14, "George", "Orwell" },
                    { 15, "Jo Nesbø", "" },
                    { 16, "Fiodor", "Dostojewski" },
                    { 17, "Gabriel", "García Márquez" },
                    { 18, "Umberto", "Eco" },
                    { 19, "Margaret", "Atwood" },
                    { 20, "C.S.", "Lewis" },
                    { 21, "Ernest", "Hemingway" },
                    { 22, "William", "Shakespeare" },
                    { 23, "Charles", "Dickens" },
                    { 24, "Jane", "Austen" },
                    { 25, "Emily", "Brontë" },
                    { 26, "Mark", "Twain" },
                    { 27, "Franz", "Kafka" },
                    { 28, "Antoine", "de Saint-Exupéry" },
                    { 29, "Jules", "Verne" },
                    { 30, "Isaac", "Asimov" },
                    { 31, "Terry", "Pratchett" },
                    { 32, "Michael", "Ende" },
                    { 33, "Astrid", "Lindgren" },
                    { 34, "Lewis", "Carroll" },
                    { 35, "Harlan", "Coben" },
                    { 36, "Mario", "Puzo" },
                    { 37, "Carlos", "Ruiz Zafón" },
                    { 38, "Patrick", "Süskind" },
                    { 39, "Khaled", "Hosseini" },
                    { 40, "Harper", "Lee" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Copies" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Copies", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 3, 3, 7, "Bieguni", 2007 },
                    { 5, 3, 6, "Harry Potter i Kamień Filozoficzny", 1997 },
                    { 6, 3, 7, "Solaris", 1961 },
                    { 9, 2, 7, "Morderstwo w Orient Expressie", 1934 },
                    { 12, 1, 7, "Nad Niemnem", 1888 },
                    { 13, 1, 5, "Lalka", 1890 },
                    { 15, 2, 7, "Człowiek nietoperz", 1997 },
                    { 17, 2, 6, "Imię róży", 1980 }
                });

            migrationBuilder.InsertData(
                table: "Borrowings",
                columns: new[] { "Id", "BookId", "BorrowDate", "ReturnDate", "Returned", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 1 },
                    { 2, 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Powieść");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kryminał");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Biografia" },
                    { 5, "Poezja" },
                    { 6, "Dramat" },
                    { 7, "Horror" },
                    { 8, "Romans" },
                    { 9, "Przygodowa" },
                    { 10, "Nauka" },
                    { 11, "Esej" },
                    { 12, "Reportaż" },
                    { 13, "Literatura dziecięca" },
                    { 14, "Literatura młodzieżowa" },
                    { 15, "Publicystyka" },
                    { 16, "Satyra" },
                    { 17, "Literatura faktu" },
                    { 18, "Historyczna" },
                    { 19, "Obyczajowa" },
                    { 20, "Psychologiczna" },
                    { 21, "Filozofia" },
                    { 22, "Religia" },
                    { 23, "Podróżnicza" },
                    { 24, "Sensacja" },
                    { 25, "Thriller" },
                    { 26, "Science fiction" },
                    { 27, "Fantasy" },
                    { 28, "Komiks" },
                    { 29, "Literatura piękna" },
                    { 30, "Literatura współczesna" },
                    { 31, "Literatura klasyczna" },
                    { 32, "Antologia" },
                    { 33, "Opowiadania" },
                    { 34, "Nowela" },
                    { 35, "Literatura kobieca" },
                    { 36, "Poradnik" },
                    { 37, "Motywacyjna" },
                    { 38, "Ekonomia" },
                    { 39, "Biznes" },
                    { 40, "Technologia" }
                });

            migrationBuilder.UpdateData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "Country", "CreateAt", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, "Polska", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "piotr.zielinski@example.com", "Piotr", "Zieliński" },
                    { 4, "Polska", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "maria.wisniewska@example.com", "Maria", "Wiśniewska" },
                    { 5, "Polska", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "krzysztof.wojcik@example.com", "Krzysztof", "Wójcik" },
                    { 6, "Polska", new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), "agnieszka.krawczyk@example.com", "Agnieszka", "Krawczyk" },
                    { 7, "Polska", new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "tomasz.mazur@example.com", "Tomasz", "Mazur" },
                    { 8, "Polska", new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "katarzyna.dabrowska@example.com", "Katarzyna", "Dąbrowska" },
                    { 9, "Polska", new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "michal.lewandowski@example.com", "Michał", "Lewandowski" },
                    { 10, "Polska", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "barbara.zajac@example.com", "Barbara", "Zając" },
                    { 11, "Polska", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "pawel.krol@example.com", "Paweł", "Król" },
                    { 12, "Polska", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "ewa.wieczorek@example.com", "Ewa", "Wieczorek" },
                    { 13, "Polska", new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "andrzej.jankowski@example.com", "Andrzej", "Jankowski" },
                    { 14, "Polska", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), "magdalena.witkowska@example.com", "Magdalena", "Witkowska" },
                    { 15, "Polska", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "marek.kowalczyk@example.com", "Marek", "Kowalczyk" },
                    { 16, "Polska", new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "joanna.szymanska@example.com", "Joanna", "Szymańska" },
                    { 17, "Polska", new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), "grzegorz.wozniak@example.com", "Grzegorz", "Woźniak" },
                    { 18, "Polska", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "aleksandra.kozlowska@example.com", "Aleksandra", "Kozłowska" },
                    { 19, "Polska", new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), "lukasz.jablonski@example.com", "Łukasz", "Jabłoński" },
                    { 20, "Polska", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "monika.pawlak@example.com", "Monika", "Pawlak" },
                    { 21, "Polska", new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), "natalia.sikora@example.com", "Natalia", "Sikora" },
                    { 22, "Polska", new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), "rafal.baran@example.com", "Rafał", "Baran" },
                    { 23, "Polska", new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), "karolina.sadowska@example.com", "Karolina", "Sadowska" },
                    { 24, "Polska", new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "dariusz.gorski@example.com", "Dariusz", "Górski" },
                    { 25, "Polska", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), "patrycja.czarnecka@example.com", "Patrycja", "Czarnecka" },
                    { 26, "Polska", new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), "wojciech.kaczmarek@example.com", "Wojciech", "Kaczmarek" },
                    { 27, "Polska", new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), "sylwia.piotrowska@example.com", "Sylwia", "Piotrowska" },
                    { 28, "Polska", new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "mariusz.adamski@example.com", "Mariusz", "Adamski" },
                    { 29, "Polska", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), "izabela.wrobel@example.com", "Izabela", "Wróbel" },
                    { 30, "Polska", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), "sebastian.lis@example.com", "Sebastian", "Lis" },
                    { 31, "Polska", new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), "beata.michalska@example.com", "Beata", "Michalska" },
                    { 32, "Polska", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "adrian.kubiak@example.com", "Adrian", "Kubiak" },
                    { 33, "Polska", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), "wiktoria.duda@example.com", "Wiktoria", "Duda" },
                    { 34, "Polska", new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), "szymon.bak@example.com", "Szymon", "Bąk" },
                    { 35, "Polska", new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "emilia.jaworska@example.com", "Emilia", "Jaworska" },
                    { 36, "Polska", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "mateusz.walczak@example.com", "Mateusz", "Walczak" },
                    { 37, "Polska", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), "julia.szymanska@example.com", "Julia", "Szymańska" },
                    { 38, "Polska", new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "artur.pawlowski@example.com", "Artur", "Pawłowski" },
                    { 39, "Polska", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), "paulina.witkowska@example.com", "Paulina", "Witkowska" },
                    { 40, "Polska", new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "kamil.rutkowski@example.com", "Kamil", "Rutkowski" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookId", "Expiration", "ReservedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, 2, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 5, 5 },
                    { 6, 6 },
                    { 9, 9 },
                    { 12, 12 },
                    { 13, 13 },
                    { 15, 15 },
                    { 17, 17 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Copies", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 4, 7, 5, "Lśnienie", 1977 },
                    { 7, 26, 5, "Władca Pierścieni", 1954 },
                    { 8, 26, 6, "Krew elfów", 1994 },
                    { 10, 10, 5, "Norwegian Wood", 1987 },
                    { 11, 5, 6, "Kod Leonarda da Vinci", 2003 },
                    { 14, 6, 6, "Rok 1984", 1949 },
                    { 16, 18, 5, "Sto lat samotności", 1967 },
                    { 18, 19, 7, "Opowieść podręcznej", 1985 },
                    { 19, 26, 5, "Lew, czarownica i stara szafa", 1950 },
                    { 20, 20, 6, "Stary człowiek i morze", 1952 },
                    { 21, 6, 7, "Romeo i Julia", 1597 },
                    { 22, 29, 5, "Wielkie nadzieje", 1861 },
                    { 23, 8, 6, "Duma i uprzedzenie", 1813 },
                    { 24, 8, 7, "Wichrowe wzgórza", 1847 },
                    { 25, 9, 5, "Przygody Tomka Sawyera", 1876 },
                    { 26, 8, 6, "Proces", 1925 },
                    { 27, 13, 7, "Mały Książę", 1943 },
                    { 28, 9, 5, "W 80 dni dookoła świata", 1873 },
                    { 29, 25, 6, "Fundacja", 1951 },
                    { 30, 26, 7, "Kolor magii", 1983 },
                    { 31, 13, 5, "Momo", 1973 },
                    { 32, 13, 6, "Dzieci z Bullerbyn", 1947 },
                    { 33, 13, 7, "Alicja w Krainie Czarów", 1865 },
                    { 34, 24, 5, "Nie mów nikomu", 2001 },
                    { 35, 9, 6, "Ojciec chrzestny", 1969 },
                    { 36, 29, 7, "Cień wiatru", 2001 },
                    { 37, 8, 5, "Pachnidło", 1985 },
                    { 38, 9, 6, "Chłopiec z latawcem", 2003 },
                    { 39, 8, 7, "Zabić drozda", 1960 },
                    { 40, 8, 5, "Pięćdziesiąt twarzy Greya", 2011 }
                });

            migrationBuilder.InsertData(
                table: "Borrowings",
                columns: new[] { "Id", "BookId", "BorrowDate", "ReturnDate", "Returned", "UserId" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 3 },
                    { 5, 5, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 5 },
                    { 6, 6, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 6 },
                    { 9, 9, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 9 },
                    { 12, 12, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 12 },
                    { 13, 13, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 13 },
                    { 15, 15, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 15 },
                    { 17, 17, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 17 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookId", "Expiration", "ReservedAt", "UserId" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 5, 5, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 6, 6, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 9, 9, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 12, 12, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), 12 },
                    { 13, 13, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Utc), 13 },
                    { 15, 15, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), 15 },
                    { 17, 17, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), 17 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 7, 7 },
                    { 8, 8 },
                    { 10, 10 },
                    { 11, 11 },
                    { 14, 14 },
                    { 16, 16 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 },
                    { 27, 27 },
                    { 28, 28 },
                    { 29, 29 },
                    { 30, 30 },
                    { 31, 31 },
                    { 32, 32 },
                    { 33, 33 },
                    { 34, 34 },
                    { 35, 35 },
                    { 36, 36 },
                    { 37, 37 },
                    { 38, 38 },
                    { 39, 39 },
                    { 40, 40 }
                });

            migrationBuilder.InsertData(
                table: "Borrowings",
                columns: new[] { "Id", "BookId", "BorrowDate", "ReturnDate", "Returned", "UserId" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 4 },
                    { 7, 7, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 7 },
                    { 8, 8, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 8 },
                    { 10, 10, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 10 },
                    { 11, 11, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 11 },
                    { 14, 14, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 14 },
                    { 16, 16, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 16 },
                    { 18, 18, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 18 },
                    { 19, 19, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 19 },
                    { 20, 20, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 20 },
                    { 21, 21, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 21 },
                    { 22, 22, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 22 },
                    { 23, 23, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 23 },
                    { 24, 24, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 24 },
                    { 25, 25, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 25 },
                    { 26, 26, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 26 },
                    { 27, 27, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 27 },
                    { 28, 28, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 28 },
                    { 29, 29, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 29 },
                    { 30, 30, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 30 },
                    { 31, 31, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 31 },
                    { 32, 32, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 32 },
                    { 33, 33, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 33 },
                    { 34, 34, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 34 },
                    { 35, 35, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 35 },
                    { 36, 36, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 36 },
                    { 37, 37, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 37 },
                    { 38, 38, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 38 },
                    { 39, 39, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 39 },
                    { 40, 40, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, false, 40 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookId", "Expiration", "ReservedAt", "UserId" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 7, 7, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 8, 8, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 10, 10, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), 10 },
                    { 11, 11, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), 11 },
                    { 14, 14, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), 14 },
                    { 16, 16, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), 16 },
                    { 18, 18, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), 18 },
                    { 19, 19, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 19 },
                    { 20, 20, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), 20 },
                    { 21, 21, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), 21 },
                    { 22, 22, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), 22 },
                    { 23, 23, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), 23 },
                    { 24, 24, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), 24 },
                    { 25, 25, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), 25 },
                    { 26, 26, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), 26 },
                    { 27, 27, new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Utc), 27 },
                    { 28, 28, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), 28 },
                    { 29, 29, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Utc), 29 },
                    { 30, 30, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30 },
                    { 31, 31, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), 31 },
                    { 32, 32, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), 32 },
                    { 33, 33, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 33 },
                    { 34, 34, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), 34 },
                    { 35, 35, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), 35 },
                    { 36, 36, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), 36 },
                    { 37, 37, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), 37 },
                    { 38, 38, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), 38 },
                    { 39, 39, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), 39 },
                    { 40, 40, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 14, 14 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 16, 16 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 17, 17 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 18, 18 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 19, 19 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 20, 20 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 21, 21 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 22, 22 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 23, 23 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 24, 24 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 25, 25 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 26, 26 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 27, 27 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 28, 28 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 29, 29 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 30, 30 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 31, 31 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 32, 32 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 33, 33 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 34, 34 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 35, 35 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 36, 36 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 37, 37 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 38, 38 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 39, 39 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 40, 40 });

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Copies" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Poezja");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Powieść");

            migrationBuilder.UpdateData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
