
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Presentation.WPF.MainApp.ViewModels;

namespace Presentation.WPF.MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow(MainViewModel viewModel) 
        {
            InitializeComponent();
            DataContext = viewModel;

        }

      
    }
}
    