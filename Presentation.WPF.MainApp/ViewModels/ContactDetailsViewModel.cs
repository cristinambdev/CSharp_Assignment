﻿

using Business.Interfaces;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WPF.MainApp.ViewModels
{
    public partial class ContactDetailsViewModel(IServiceProvider serviceProvider) : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        [ObservableProperty]
        private Contact _contact = new();

        [RelayCommand]
        private void GoToContactEditView()
        {
            var contactEditViewModel = _serviceProvider.GetRequiredService<ContactEditViewModel>();
            contactEditViewModel.Contact = Contact;


            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = contactEditViewModel;

        }


        [RelayCommand]
        private void Cancel()
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();

        }
    }
}
