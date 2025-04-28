using System;
using System.ComponentModel.DataAnnotations;

namespace PO2_projekt.Models;

public class Reader
{
    public int Id { get; set; }

    [Required] 
    [MaxLength(255)] 
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    public string? Country { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.Now;
    
    // Relacje
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    
}