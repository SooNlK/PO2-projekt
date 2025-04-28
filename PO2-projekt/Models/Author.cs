using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PO2_projekt.Models;

public class Author 
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;

    // Relacje
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}