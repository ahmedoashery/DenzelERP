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

        public void NewUser(string name, string email, string loginName, string password)
        {
            DataContext.Users.Add(new User {
                Name = name,
                Email  = email,
                LoginName = loginName,
                LoginPassword= password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                HangedAt  = DateTime.Now,
                DeletedAt = DateTime.Now
            });
            DataContext.SaveChanges();
        }
    }
}
