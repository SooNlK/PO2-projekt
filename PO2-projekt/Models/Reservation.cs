using System;
using System.ComponentModel.DataAnnotations;

namespace PO2_projekt.Models;

{
    public class Reservation
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public Reader User { get; set; } = null!;

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public DateTime ReservedAt { get; set; } = DateTime.Now;

        public DateTime? Expiration { get; set; }
    }
}
