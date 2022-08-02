using ContactBook.Database;
using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class ContactService : IContactService
    {
        private AppDbContext database;
        public ContactService(AppDbContext database)
        {
            this.database = database;
        }
        public ResponseMessage CreateContact(NewContactDTO request, User user, out bool isContactCreated)
        {
            var newContact = new Contact()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                TelephoneNumber = request.TelephoneNumber,
                Email = request.Email,
                Address = request.Address,
                UserId = user.Id,
            };
            if (newContact == null)
            {
                isContactCreated = false;
                return new ResponseMessage()
                {
                    Message = "Contact cannot be added"

                };
            }
            else
            {
                isContactCreated = true;
                database.Contacts.Add(newContact);
                database.SaveChanges();
                return new ResponseMessage()
                {
                    Message = "Contact has been added"

                };
            }
        }

        public ResponseMessage EditContact(EditContactDTO input, Contact editedContact, User user, out bool isContactEdited)
        {
            if (editedContact != null && editedContact.UserId == user.Id)
            {
                if (!string.IsNullOrEmpty(input.NewFirstName))
                    editedContact.FirstName = input.NewFirstName;
                if (!string.IsNullOrEmpty(input.NewLastName))
                    editedContact.LastName = input.NewLastName;
                if (input.NewTelephoneNumber == null)
                    editedContact.TelephoneNumber = input.NewTelephoneNumber;
                if (!string.IsNullOrEmpty(input.NewEmail))
                    editedContact.Email = input.NewEmail;
                if (!string.IsNullOrEmpty(input.NewAddress))
                    editedContact.Address = input.NewAddress;
                database.SaveChanges();
                isContactEdited = true;
                return new ResponseMessage
                {
                    Message = "Contact has been changed"
                };
            }
            isContactEdited = false;
            return new ResponseMessage
            {
                Message = "This contact does not exist in your account"
            };
        }

        public Contact GetContactById(int contactId)
        {
            return database.Contacts.SingleOrDefault(c => c.Id == contactId);
        }

        public ContactDTO ShowMeMyContact(int contactId, User user, out bool isValid)
        {
            var contact = GetContactById(contactId);
            if (contact != null && contact.UserId == user.Id)
            {
                var contactDTO = new ContactDTO()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    TelephoneNumber = contact.TelephoneNumber,
                    Email = contact.Email,
                    Address = contact.Address,
                };
                isValid = true;
                return contactDTO;
            }
            isValid = false;
            return null;

        }

        public ResponseMessage DeleteContact(int contactId, User user, out bool isContactDeleted)
        {
            var contact = GetContactById(contactId);
            if (contact != null && contact.UserId == user.Id)
            {
                database.Contacts.Remove(contact);
                database.SaveChanges();
                isContactDeleted = true;
                return new ResponseMessage
                {
                    Message = "Contact has been deleted"
                };
            }
            isContactDeleted = false;
            return new ResponseMessage
            {
                Message = "This contact does not exist in your account"
            };

        }
    }


}

