namespace TicketPurchaseService.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    /*
    [Key]
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    */

    public int? PassengerId { get; set; }
    public Passenger? Passenger { get; set; }

    public virtual ICollection<Order>? Orders { get; set;}
}
