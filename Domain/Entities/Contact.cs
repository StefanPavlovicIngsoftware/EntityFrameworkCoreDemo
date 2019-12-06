namespace Domain.Entities
{
    public class Contact 
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
