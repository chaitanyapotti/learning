using FriendOrganizer.Model;

namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        //This is created by using command "enable-migrations" in package manager console
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Friends.AddOrUpdate(
                f => f.FirstName,
                new Friend() { FirstName = "Thomas", LastName = "Huber" },
                new Friend() { FirstName = "Andreas", LastName = "Boehler" },
                new Friend() { FirstName = "Julia", LastName = "Huber" },
                new Friend() { FirstName = "Chrissi", LastName = "Egin" }
            );
        }
    }
}
