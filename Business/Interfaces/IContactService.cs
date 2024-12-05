using Business.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool Create(ContactRegistrationForm form);
        IEnumerable<Contact> GetAll();
    }
}