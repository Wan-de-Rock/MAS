using System.ComponentModel.DataAnnotations;

namespace TicketPurchaseService.Models;

public class Person
{
    public int Id { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string? FirstName { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string? LastName { get; set; }
}
