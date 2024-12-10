using Business.Models;
using Business.Services;

namespace Presentation.Console.MainApp.Tests.Services;

public class ContactService_Tests

{
    private readonly ContactService _contactService = new();

    [Fact]

    public void ContactService_CreateNewContact_ShouldReturnTrueWhenContactCreate()
    {
        //Arrange
        var contactRegistrationForm = new ContactRegistrationForm();
        //Act
        var result = _contactService.CreateNewContact(contactRegistrationForm);

        //Assert
        Assert.True(result);

    }

    //[Fact]

    //public void ContactService_SetNewId_ShoudlGenerate)
    //{
    //    //Arrange

    //    var contactService = new ContactService();

    //    //Act
    //    var result = contactService.SetProductId();

    //    //Assert
    //    Assert.Equal();
    //}
}
