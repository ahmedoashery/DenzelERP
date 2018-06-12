using Data.Repository;
using Data.Repository.UnitOfWork;
using Modules.Users.Services;
using Modules.Users.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Modules.Users.ViewModels
{
    public class NewUserViewModel : BindableBase
    {

        private string _name;
        private string _email;
        private string _loginname;
        private string _loginPassword;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public string LoginName
        {
            get { return _loginname; }
            set { SetProperty(ref _loginname, value); }
        }

        public string LoginPassword
        {
            get { return _loginPassword; }
            set { SetProperty(ref _loginPassword, value); }
        }
        public NewUserViewModel()
        {
            CreateUserCommand = new DelegateCommand<object>(Save)
                                                                 .ObservesProperty(()=>LoginName)
                                                                 .ObservesProperty(()=>LoginPassword);
        }

        public DelegateCommand<object> CreateUserCommand { get; set; }

        private void Save(object SecuredParameter)
        {
            var passwordContainer = SecuredParameter as ISecurePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.SecurePassword;
                LoginPassword = ConvertToUnsecureString(secureString);
            }

            DataContext Context = new DataContext();
            //Context.Users.(Name, LoginName, LoginPassword);
            UnitOfWork uof = new UnitOfWork(Context);
            uof.Users.NewUser(Name, Email, LoginName, LoginPassword);
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
