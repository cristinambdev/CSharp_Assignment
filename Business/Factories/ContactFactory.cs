using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }

    public static Contact Create(ContactRegistrationForm contactRegistrationForm) => new()
    {
        Id = UniqueIdentifierGenerator.GenerateUniqueId(),
        FirstName = contactRegistrationForm.FirstName,
        LastName = contactRegistrationForm.LastName,
        Email = contactRegistrationForm.Email,
        PhoneNumber = contactRegistrationForm.PhoneNumber,
        Address = contactRegistrationForm.Address,
        PostNumber = contactRegistrationForm.PostNumber,
        City = contactRegistrationForm.City
    };

    //internal static Contact Create(ContactRegistrationForm form)
    //{
    //    return new Contact()
    //    {
    //        Id = UniqueIdentifierGenerator.GenerateUniqueId(),
    //        FirstName = form.FirstName,
    //        LastName = form.LastName,
    //        Email = form.Email,
    //        PhoneNumber = form.PhoneNumber,
    //        Address = form.Address,
    //        PostNumber = form.PostNumber,
    //        City = form.City
    //    };
    //}

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

