using Business.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool CreateNewContact(ContactRegistrationForm contactRegistrationForm);
        IEnumerable<Contact> GetAll();
        bool UpdateContact(Contact contact);
    }
}