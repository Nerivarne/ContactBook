namespace ContactBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
