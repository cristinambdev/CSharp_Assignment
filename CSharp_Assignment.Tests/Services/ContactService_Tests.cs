using Business.Interfaces;
using Business.Models;
using Moq;

namespace Presentation.Console.MainApp.Tests.Services;

public class ContactService_Tests

{
   
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests() //use a constructor to instatiate the two items above.
    {
        _contactServiceMock = new Mock<IContactService>();
        _contactService = _contactServiceMock.Object;
    }

    [Fact]

    public void ContactService_CreateNewContact_ShouldReturnTrueWhenContactCreated()
    {
        //Arrange
        var contactRegistrationForm = new ContactRegistrationForm 
        {FirstName = "Pepe", LastName = "Lopez", Email = "lopez@domain.com", PhoneNumber = "0767051377", Address = "Denväg, 34", PostNumber =  "45678", City = "Här" };

        _contactServiceMock
            .Setup(contactService => contactService.CreateNewContact(contactRegistrationForm))
            .Returns(true);

        //Act
        var result = _contactService.CreateNewContact(contactRegistrationForm);

        //Assert
        Assert.True(result);
        _contactServiceMock.Verify(contactService => contactService.CreateNewContact(contactRegistrationForm), Times.Once);

    }

    [Fact]

    public void ContactService_GetAll_ShouldReturnListOfContacts()
    {
        //Arrange

        var contacts = new List<Contact>()
        {
            new Contact {
             Id ="1",
             FirstName = "Jag",
             LastName = "Själv",
             Email = "linn@domain.com",
             PhoneNumber= "7777444332",
             Address = "Hit 45",
             PostNumber = "23907",
             City = "Här"},

          new Contact {
             Id ="2",
             FirstName = "Du",
             LastName = "Själv",
             Email = "du@domain.com",
             PhoneNumber= "23456790",
             Address = "Gatan 23",
             PostNumber = "76523",
             City = "Där" },

        };
           
        _contactServiceMock
           .Setup(contactService => contactService.GetAll())
           .Returns(contacts);

        //Act
        var result = _contactService.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Jag", result.First().FirstName);
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
