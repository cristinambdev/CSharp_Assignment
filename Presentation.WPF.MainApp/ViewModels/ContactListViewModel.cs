using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Presentation.WPF.MainApp.ViewModels;

public partial class ContactListViewModel: ObservableObject
{
    private readonly IContactService _contactService;
    private readonly IServiceProvider _serviceProvider;


    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];

    public ContactListViewModel(IContactService contactService, IServiceProvider serviceProvider)
    {
        _contactService = contactService;
        _serviceProvider = serviceProvider;

        _contacts = new ObservableCollection<Contact>(_contactService.GetAll());
    }

    [RelayCommand]
    private void GoToAddView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactAddViewModel>();

    }

    [RelayCommand]
    private void GoToContactDetailsView(Contact contact)
    {
        var userDetailsViewModel = _serviceProvider.GetRequiredService<ContactDetailsViewModel>();
        userDetailsViewModel.Contact = contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = userDetailsViewModel;

    }




}
