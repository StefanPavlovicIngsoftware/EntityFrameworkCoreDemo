namespace Application.DataTransferObjects
{
    public class ContactDto 
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual CustomerDto Customer { get; set; }
    }
}
