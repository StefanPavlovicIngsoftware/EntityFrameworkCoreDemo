namespace Domain.SupportEntities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
