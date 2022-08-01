namespace ContactBook.Models
{
    public class EditContactDTO
    {
        public int ContactId { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public int NewTelephoneNumber { get; set; }
        public string NewEmail { get; set; }
        public string NewAddress { get; set; }
    }
}
