﻿using Business.Factories;
using Business.Models;

namespace Business.Services;

public class MenuDialogs
{
    private readonly ContactService _contactService = new();

    public void Run()
    {
        while (true)
        {
            MainMenu();
            
        }
    }

    private string MainMenu()
    {
        Console.Clear();
        Console.WriteLine("WELCOME TO THE PROGRAM!");
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
                CreateOption();
                break;

            case "2":
                ViewOption();
                break;

            default:
                InvalidOption();
                break;
        }
        return option;
    }


    private void CreateOption()
    {
        var contactRegistrationForm = ContactFactory.Create();

        Console.Clear();

        Console.Write("Enter your first name: ");
        contactRegistrationForm.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        contactRegistrationForm.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        contactRegistrationForm.Email = Console.ReadLine()!;

        Console.Write("Enter your phone number: ");
        contactRegistrationForm.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your address: ");
        contactRegistrationForm.Address = Console.ReadLine()!;

        Console.Write("Enter your post number: ");
        contactRegistrationForm.PostNumber = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        contactRegistrationForm.City = Console.ReadLine()!;

        bool result = _contactService.Create(contactRegistrationForm);

        if (result)
        {
            OutputDialog("Contact was succesfully created");
        }
        else
        {
            OutputDialog("Contact could not be created");
        }

        

    }
    private void ViewOption()
    {
        var contacts = _contactService.GetAll();

        Console.Clear();

        foreach(var contact in contacts)
        {
            Console.WriteLine($"{"Id:", -15}{contact.Id}");
            Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{"Email:",-15}{contact.Email}");
            Console.WriteLine($"{"Telephone:",-15}{contact.PhoneNumber}");
            Console.WriteLine($"{"Address:",-15}{contact.Address} , {contact.PostNumber} , {contact.City} ");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }

    private static CheckNumber(string PhoneNumber)
    {
        foreach(char c in PhoneNumber)
        {
            if (c < 0 || c > 9)
            {
            
              Console.WriteLine("Please, provide a valid number");
          
            }
        }


    }
    
    private void QuitOption()
    {
        Console.Clear();
        Console.Write("Do you want to exit this program? (y/n): ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }

    }

    private void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("You must enter a valid option. ");
        Console.ReadKey();

    }

    private void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }

}
