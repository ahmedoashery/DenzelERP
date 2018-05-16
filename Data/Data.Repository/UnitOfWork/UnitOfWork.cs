using Data.Repository.Repositories;

namespace Data.Repository.UnitOfWork
{
    public class UnitOfWork
    {
        protected readonly DataContext dataContext;

        public UnitOfWork(DataContext _dataContext)
        {
            dataContext = _dataContext;

            Users = new UserRepository(dataContext);
        }

        public UserRepository Users { get; set; }

        public int Complete()
        {
            return dataContext.SaveChanges();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
