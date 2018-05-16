using Modules.Users.Services;
using System.Security;
using System.Windows.Controls;

namespace Modules.Users.Views
{
    /// <summary>
    /// Interaction logic for NewUser
    /// </summary>
    public partial class NewUser : UserControl, ISecurePassword
    {
        public NewUser()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword
        {
            get { return Password.SecurePassword; }
        }
    }
}
