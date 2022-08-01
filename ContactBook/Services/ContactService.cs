using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class ContactService : IContactService
    {
        public ResponseMessage CreateContact(NewContactDTO newContact, User user, out bool isContactCreate)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage DeleteRoomReservation(string deletionToken, int roomReservationId, out bool deletionSuccessful)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditContact(EditContactDTO input, Contact editedContact, out bool validRequest)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactById(int contactId)
        {
            throw new NotImplementedException();
        }

        public bool IsEditFormValid(EditContactDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
