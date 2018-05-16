using Data.Repository;
using Data.Repository.UnitOfWork;
using Prism.Mvvm;

namespace Modules.Users.ViewModels
{
    public class UsersListViewModel : BindableBase
    {
        public UsersListViewModel()
        {
            
            UnitOfWork uof = new UnitOfWork(new DataContext());

            Name = uof.Users.GetUserById(2).Name;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
