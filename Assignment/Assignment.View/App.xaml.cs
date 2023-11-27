using System.Windows;
using Assignment.View.View;

namespace Assignment.View
{
    
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView  = new LoginView();
            loginView.Show();
        }
    }
}
