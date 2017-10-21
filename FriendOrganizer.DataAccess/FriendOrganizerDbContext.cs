using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    { 
        public DbSet<Friend> Friends { get; set; }

        public FriendOrganizerDbContext() : base("FriendOrganizerDb")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Fluent API //Specifies the constraints here or in a separate class - Clean Model
            //modelBuilder.Entity<Friend>().Property(f => f.FirstName).IsRequired().HasMaxLength(200);

            //Fluent API - Separate class
            //modelBuilder.Configurations.Add(new FriendConfiguration());

            //For data annotations, add attributes to the model class which can also be used for validation of the UI.

        }
    }

    public class FriendConfiguration : EntityTypeConfiguration<Friend>
    {
        public FriendConfiguration()
        {
            Property(f => f.FirstName).IsRequired().HasMaxLength(50);
        }
    }
}
