using Data.Repository.Domain;
using System.Data.Entity;

namespace Data.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DenzelConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
