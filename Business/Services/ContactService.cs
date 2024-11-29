using Business.Factories;
using Business.Helpers;
using Business.Models;
using System.Diagnostics;


namespace Business.Services;

public class ContactService
{
    private readonly List<ContactEntity> _contacts = [];

    public bool Create(ContactRegistrationForm form)
    {
        try
        {
            ContactEntity contactEntity = ContactFactory.Create(form);
            contactEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();

            _contacts.Add(contactEntity);
            return true;

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public void ClearList()
    {
        _contacts.Clear();
    }

    
    public IEnumerable<Contact>GetAll()
    {
        //var list = new List<Contact>();
        //foreach (var contactEntity in _contacts)
        //{
        //    list.Add(ContactFactory.Create(contactEntity));
        //}
        //return list;
        return _contacts.Select(ContactFactory.Create);
    }

}
