using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WPF.MainApp.ViewModels;
using Presentation.WPF.MainApp.Views;
using System.Windows;

namespace Presentation.WPF.MainApp;


public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {

        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IFileService, FileService>();
                services.AddTransient<IContactService, ContactService>();
            
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddTransient<ContactListViewModel>();
                services.AddTransient<ContactListView>();

                services.AddTransient<ContactAddViewModel>();
                services.AddTransient<ContactAddView>();

                services.AddTransient<ContactDetailsViewModel>();
                services.AddTransient<ContactDetailsView>();

                services.AddTransient<ContactEditViewModel>();
                services.AddTransient<ContactEditView>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<ContactListViewModel>();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
