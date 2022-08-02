using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface IContactService
    {
        ResponseMessage CreateContact(NewContactDTO request, User user, out bool isContactCreated);
        Contact GetContactById(int contactId);
        ResponseMessage EditContact(EditContactDTO input, Contact editedContact, User user, out bool isContactEdited);
        ContactDTO ShowMeMyContact(int contactId, User user, out bool isValid);
        ResponseMessage DeleteContact(int contactId, User user, out bool isContactDeleted);
    }
}
