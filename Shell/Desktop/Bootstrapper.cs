using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Users;
using Modules.Users.Views;
using Shell.Desktop.Views;

namespace Desktop
{
    class Bootstrapper : UnityBootstrapper
    {
        private bool session = true;

        protected override DependencyObject CreateShell()
        {
            // check logged in user
            if (session == true)
            {
                return Container.Resolve<MainWindow>();
            }
            else
            {
                return Container.Resolve<Login>();
            }
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(UsersModule));
        }
    }
}
