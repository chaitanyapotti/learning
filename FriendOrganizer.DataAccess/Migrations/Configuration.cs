using System.Collections.Generic;
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

            context.ProgrammingLanguages.AddOrUpdate(
                pl => pl.Name,
                new ProgrammingLanguage(){Name = "C#"},
                new ProgrammingLanguage() { Name = "TypeScript" },
                new ProgrammingLanguage() { Name = "F#" },
                new ProgrammingLanguage() { Name = "Swift" },
                new ProgrammingLanguage() { Name = "Java" }
                );

            context.SaveChanges();

            context.FriendPhoneNumbers.AddOrUpdate(
                f => f.Number,
                new FriendPhoneNumber(){Number = "+919930466714", FriendId = context.Friends.First().Id});

            context.Meetings.AddOrUpdate(
                m => m.Title,
                new Meeting()
                {
                    Title = "Watching Soccer",
                    DateFrom = new DateTime(2017,12,26),
                    DateTo = new DateTime(2017, 12, 31),
                    Friends = new List<Friend>()
                    {
                        context.Friends.Single(x => x.FirstName=="Thomas" && x.LastName == "Huber"),
                        context.Friends.Single(x => x.FirstName == "Andreas" && x.LastName == "Boehler")
                    }
                });
        }
    }
}
