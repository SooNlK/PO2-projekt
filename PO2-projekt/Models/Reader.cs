using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PO2_projekt.Models;

public class Reader
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Imię jest wymagane.")]
    [MaxLength(255)] 
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Nazwisko jest wymagane.")]
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email jest wymagany.")]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    public string? Country { get; set; }
    
    public DateTime CreateAt { get; set; }
    
    // Relacje
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public string FullName => $"{FirstName} {LastName}";
}