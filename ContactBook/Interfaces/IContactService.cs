using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface IContactService
    {
        ResponseMessage CreateContact(NewContactDTO newContact, User user, out bool isContactCreate);
        Contact GetContactById(int contactId);
        ResponseMessage EditContact(EditContactDTO input, Contact editedContact, out bool validRequest);
        bool IsEditFormValid(EditContactDTO input);
        ResponseMessage DeleteRoomReservation(string deletionToken, int roomReservationId, out bool deletionSuccessful);
    }
}
