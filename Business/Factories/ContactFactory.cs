using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }

    internal static Contact Create(ContactRegistrationForm form)
    {
        return new Contact()
        {
            Id = UniqueIdentifierGenerator.GenerateUniqueId(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            Address = form.Address,
            PostNumber = form.PostNumber,
            City = form.City
        };
    }

    internal static Contact Create(Contact entity)
    { 
        return new Contact()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            PostNumber = entity.PostNumber,
            City = entity.City
        };
    }
}

