using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PO2_projekt.ViewModels;

namespace PO2_projekt.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    public int YearPublished { get; set; }

    public int Copies { get; set; } = 1;

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    // Relacje
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}