﻿using Business.Factories;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;


namespace Business.Services;

public class ContactService : IContactService
{
    private List<Contact> _contacts = [];
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }//suggested by VS because of error in constructor in FileService_Tests

    public bool CreateNewContact(ContactRegistrationForm contactRegistrationForm)
    {
        try
        {
            Contact contact = ContactFactory.Create(contactRegistrationForm);

            contact.Id = UniqueIdentifierGenerator.GenerateUniqueId();

            _contacts.Add(contact);
            _fileService.SaveListToFile(_contacts);
            return true;

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Contact> GetAll()
    {
        var contacts = _fileService.LoadListFromFile();
        //_contacts = contacts.Select(ContactFactory.Create);
        _contacts = contacts.Select(ContactFactory.Create).ToList(); //Generated by CHAT GPT: My original code in line 39 was throwing an error because
                                                                     //the method is returning an IEnumerable list and not just a simple List
                                                                     //so the result needs to be converted by using ".ToList()".

        var list = new List<Contact>();
        foreach (var contactEntity in _contacts)
        {
            list.Add(ContactFactory.Create(contactEntity));
        }
        return list;



    }
}

 
