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
                services.AddSingleton<IFileService>(new FileService(AppDomain.CurrentDomain.BaseDirectory, "list.json"));
                services.AddTransient<IContactService, ContactService>();
            
                
                services.AddTransient<ContactListViewModel>();
                services.AddTransient<ContactAddViewModel>();
                services.AddTransient<ContactDetailsViewModel>();
                services.AddTransient<ContactEditViewModel>();

                services.AddTransient<ContactListView>();
                services.AddTransient<ContactAddView>();
                services.AddTransient<ContactDetailsView>();
                services.AddTransient<ContactEditView>();

                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
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
