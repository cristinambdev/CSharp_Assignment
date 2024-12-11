using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Business.Services;

public class MainMenuDialogs(IContactService contactService) : IMainMenuDialogs
{
    private readonly IContactService _contactService = contactService;


    public string ShowMainMenu()
    {
        while (true)
        {

            Console.Clear();
            Console.WriteLine("##### WELCOME TO THE PROGRAM! #####");
            Console.WriteLine($"{"1.",-5} CREATE CONTACT");
            Console.WriteLine($"{"2.",-5} SHOW CONTACT");
            Console.WriteLine($"{"Q.",-5} LEAVE PROGRAM");
            Console.WriteLine("-----------------------------------");
            Console.Write("Choose your option: ");
            var option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "q":
                    QuitOption();
                    break;

                case "1":
                    CreateContact();
                    break;

                case "2":
                    ViewContacts();
                    break;

                default:
                    InvalidOption();
                    break;
            }
        }
    }

    public void CreateContact()
    {
        var contactRegistrationForm = ContactFactory.Create();

        Console.Clear();

        contactRegistrationForm.FirstName = PromptAndValidate("Enter your first name: ", nameof(contactRegistrationForm.FirstName));
        contactRegistrationForm.LastName = PromptAndValidate("Enter your last name: ", nameof(contactRegistrationForm.LastName));
        contactRegistrationForm.Email = PromptAndValidate("Enter your email: ", nameof(contactRegistrationForm.Email));
        contactRegistrationForm.PhoneNumber = PromptAndValidate("Enter your phone number: ", nameof(contactRegistrationForm.PhoneNumber));
        contactRegistrationForm.Address = PromptAndValidate("Enter your address: ", nameof(contactRegistrationForm.Address));
        contactRegistrationForm.PostNumber = PromptAndValidate("Enter your post number: ", nameof(contactRegistrationForm.PostNumber));
        contactRegistrationForm.City = PromptAndValidate("Enter your city: ", nameof(contactRegistrationForm.City));

        bool result = _contactService.CreateNewContact(contactRegistrationForm);

        if (result)
        {
            OutputDialog("Contact was succesfully created!");
        }
        else
        {
            OutputDialog("Contact could not be created");
        }

    }

    public string PromptAndValidate(string prompt, string propertyName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write(prompt);
            var input = Console.ReadLine() ?? string .Empty;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(new ContactRegistrationForm()) { MemberName = propertyName };

            if(Validator.TryValidateProperty(input, context, results))
                return input;
            Console.WriteLine($"{results[0].ErrorMessage}. Please Try again");
        }
    }
    public void ViewContacts()
    {
        var contacts = _contactService.GetAll();

        Console.Clear();

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id:",-15}{contact.Id}");
            Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{"Email:",-15}{contact.Email}");
            Console.WriteLine($"{"Telephone:",-15}{contact.PhoneNumber}");
            Console.WriteLine($"{"Address:",-15}{contact.Address}  {contact.PostNumber}  {contact.City} ");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }


    public void QuitOption()
    {
        Console.Clear();
        Console.Write("Do you want to exit this program? (y/n): ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }

    }

    public void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("You must enter a valid option.");
        Console.ReadKey();

    }

    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }


}
