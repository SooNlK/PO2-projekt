using System;
using System.ComponentModel.DataAnnotations;

namespace PO2_projekt.Models;

{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
