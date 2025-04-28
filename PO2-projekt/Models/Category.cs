using System;
using System.ComponentModel.DataAnnotations;

namespace PO2_projekt.Models;

{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
