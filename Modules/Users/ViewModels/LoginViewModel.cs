using Data.Repository;
using Data.Repository.Domain;
using Data.Repository.UnitOfWork;
using Modules.Users.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Modules.Users.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        UnitOfWork data = new UnitOfWork(new DataContext());
        User user = null;
        public DelegateCommand<object> LoginCommand { get; set; }

        //private User CurrentUser = null;

        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _session = null;
        public string Session
        {
            get { return _session; }
            set { SetProperty(ref _session, value); }
        }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand<object>(Login, CanLogin)
                                                                       .ObservesProperty(() => Username)
                                                                       .ObservesProperty(() => Password);
        }

        private bool CanLogin(object PasswordParameter)
        {
            return !String.IsNullOrWhiteSpace(Username);
        }

        private void Login(object PasswordParameter)
        {
            Password = UnSecuredString(PasswordParameter);
            
            User user = data.Users.Authenticate(Username, Password);

            if (user != null)
            {
                Message = "Welcome! =>  " + user.Name;
                Password = null;
            }
            else
            {
                Message = "Oops! Try Again";
                return;
            }
        }

        private string UnSecuredString(object SecuredPassword)
        {
            var passwordContainer = SecuredPassword as ISecurePassword;
            if (passwordContainer != null)
            {
                var securedString = passwordContainer.SecurePassword;
                var unSecuredString = ConvertToUnsecureString(securedString);
                return unSecuredString;
            }
            return null;
        }
        private string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
