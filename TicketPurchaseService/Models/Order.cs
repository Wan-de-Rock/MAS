namespace TicketPurchaseService.Models
{
    public class Order
    {
        public int Id { get; set; }
        /*
        private decimal _totalPrice => Travels.Sum(x => x.TotalPrice);

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            //set { _totalPrice = value; }
        }
        */
        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public ICollection<Travel>? Travels { get; set; }// = new HashSet<Travel>();
        /*

        public Order() { }
        public Order(User user)
        {
            if (user is not null)
            {
                User = user;
                UserId = user.Id;
            }
        }
        public Order(User user, ICollection<Travel> travels) : this(user)
        {
            if (travels is not null)
            {
                Travels = new HashSet<Travel>(travels);
            }
        }

        public bool AddTravel (Passenger passenger)
        {
            return Travels.Add(new Travel(passenger));
        }
        public bool AddTravel (Travel travel)
        {
            return Travels.Add(travel);
        }
        */
    }
}
