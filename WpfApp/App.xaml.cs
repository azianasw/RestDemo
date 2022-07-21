using System.Windows;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new TarifAirTangkiViewModel(new TarifAirTangkiService(), new Notification())
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
