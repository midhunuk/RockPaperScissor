using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RPSGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindowViewModel = new MainWindowViewModel();
            this.MainWindow = new MainWindow();
            this.MainWindow.DataContext = mainWindowViewModel;
            this.MainWindow.Show();
        }
    }
}
