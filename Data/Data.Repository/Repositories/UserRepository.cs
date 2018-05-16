using System;
using System.Data.Entity;
using System.Linq;
using Data.Repository.Core;
using Data.Repository.Domain;

namespace Data.Repository.Repositories
{
    public class UserRepository : Repository<User>
    {

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
        public UserRepository(DataContext _context) : base(_context)
        {
        }

        public User GetUserById(int id)
        {
            return DataContext.Users.Find(id);
        }

        public User Authenticate(string username, string password)
        {
            return DataContext.Users.FirstOrDefault(u => u.LoginName == username && u.LoginPassword == password);
        }

    }
}
