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
        public ResponseMessage CreateContact(NewContactDTO request, User user, out bool isContactCreate)
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
                isContactCreate = false;
                return new ResponseMessage()
                {
                    Message = "Contact cannot be added"

                };
            }
            else
            {
                isContactCreate = true;
                database.Contacts.Add(newContact);
                database.SaveChanges();
                return new ResponseMessage()
                {
                    Message = "Contact has been added"

                };
            }
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
