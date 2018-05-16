namespace Data.Repository.Migrations
{
    using Data.Repository.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Repository.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Repository.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            #region Add Users
            //var users = new List<User>
            //{
            //    new User
            //    {
            //        LoginName = "Mosh Hamedani",
            //        LoginPassword = "pwd",
            //        CreatedAt = DateTime.Now
            //    },
            //    new User
            //    {
            //        Name = "Anthony Alicea",
            //        LoginPassword = "pwd",
            //        CreatedAt = DateTime.Now
            //    },
            //    new User
            //    {
            //        Name = "Eric Wise",
            //        LoginPassword = "pwd",
            //        CreatedAt = DateTime.Now
            //    },
            //    new User
            //    {
            //        Name = "Tom Owsiak",
            //        LoginPassword = "pwd",
            //        CreatedAt = DateTime.Now
            //    },
            //    new User
            //    {
            //        Name = "John Smith",
            //        LoginPassword = "pwd",
            //        CreatedAt = DateTime.Now
            //    }
            //};

            //foreach (var user in users)
            //    context.Users.AddOrUpdate(a => a.Id, user);
            #endregion
        }
    }
}
