

using Business.Factories;
using Business.Models;

namespace Presentation.Console.MainApp.Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    //Naming convention: ClassName_MethodName_ExpectedResult
    public void ContactFactory_Create_ShouldReturnContactRegistrationForm()
    {
        //Arrange- preparation, gather variables, classes, objects, mocks, etc that make the function work


        //Act - Invoke the method we are testing
        ContactRegistrationForm result = ContactFactory.Create();


        //Assert - check/test that the method behaved as expected.
        Assert.IsType<ContactRegistrationForm>(result);
    }

    [Theory]
    [InlineData("Pepe", "Lopez", "lopez@domain.com", "0767051377", "Denväg, 34", "45678", "Här")]
    [InlineData("Pepe", "", "lopez@domain.com", "0767051377", "Denväg, 44", "45678", "Där")]
    [InlineData("Juan", "Lopez", "lopez@domain.com", "0767051377", "Denväg, 34", "45678", "Här")]


    public void ContactFactory_Create_ReturnAContactWhenContactRegistrationFormIsSupplied
        (string firstname, string lastname, string email, string phonenumber, string address, string postnumber, string city)
    {
        //Arrange

        ContactRegistrationForm contactRegistrationForm = new() 
        { FirstName= firstname, 
         LastName = lastname, 
         Email = email, 
         PhoneNumber= phonenumber,
         Address = address,
         PostNumber = postnumber,
         City = city
        };

        //Act

        Contact result = ContactFactory.Create(contactRegistrationForm);

        //Assert
        Assert.IsType<Contact>(result);
        Assert.Equal(contactRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(contactRegistrationForm.LastName, result.LastName);
        Assert.Equal(contactRegistrationForm.Email, result.Email);
        Assert.Equal(contactRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contactRegistrationForm.Address, result.Address);
        Assert.Equal(contactRegistrationForm.PostNumber, result.PostNumber);
        Assert.Equal(contactRegistrationForm.City, result.City);
    }

   
}
