using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Calls.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string CountryOfService { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /* If you don't specify a connection string or the name of one explicitly, 
         * Entity Framework assumes that the connection string name is the same as the class name */
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        /*
         * You could have omitted the DbSet<Enrollment> and  DbSet<Course> [in this case, the DbSet<Phone> and DbSet<EmailAddress>] statements and it would work the same. 
         * The Entity Framework would include them implicitly because the Student [Call] entity references the Enrollment [Phone and EmailAddress] entities
         * [and the Enrollment entity references the Course entity]. 
         * http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
         */
        public DbSet<Call> Calls { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Congregation> Congregations { get; set; }

        /* The modelBuilder.Conventions.Remove statement in the OnModelCreating method prevents table names from being pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        */
    }
}