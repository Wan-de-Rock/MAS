using System.ComponentModel.DataAnnotations;

namespace TicketPurchaseService.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public ICollection<Travel>? Travels { get; set; }
    }
}
