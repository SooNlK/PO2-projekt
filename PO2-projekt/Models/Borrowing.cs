using System;
using System.ComponentModel.DataAnnotations;

namespace PO2_projekt.Models

{
    public class Borrowing
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        [Required]
        public int UserId { get; set; }
        public Reader User { get; set; } = null!;

        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool Returned { get; set; } = false;
    }
}
