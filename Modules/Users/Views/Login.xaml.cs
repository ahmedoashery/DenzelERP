using Modules.Users.Services;
using System.Security;
using System.Windows.Controls;

namespace Modules.Users.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class Login : UserControl, ISecurePassword
    {
        public Login()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword
        {
            get
            {
                return UserPassword.SecurePassword;
            }
        }
    }
}
