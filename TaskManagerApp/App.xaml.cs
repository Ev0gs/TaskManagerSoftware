using System.Configuration;
using System.Data;
using System.Windows;

namespace TaskManagerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var db = DBContextFactory.Create())
            {
                db.Database.EnsureCreated();
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
