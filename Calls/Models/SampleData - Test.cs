using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.IO;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Calls.Models
{
    public class SampleData : DropCreateDatabaseAlways<ApplicationDbContext>
    //public class SampleData : CreateDatabaseIfNotExists<CITPropTrackDB>
    /*
     * An implementation of IDatabaseInitializer<TContext>that will delete, recreate, and optionally re-seed the database with data 
     * only if the model has changed since the database was created. 
     * This is achieved by writing a hash of the store model to the database when it is created and then comparing that hash with one generated from the current model. 
     * To seed the database, create a derived class and override the Seed method.
     * 
     * DropCreateDatabaseIfModelChanges<TContext>.Seed Method: A method that should be overridden to actually add data to the context for seeding. The default implementation does nothing.
     * protected virtual void Seed(TContext context)
     * 
     * Notes: 
     * 1. protected :A protected member is accessible within its class and by derived class instances only if the access occurs through the derived class type (See http://msdn.microsoft.com/en-us/library/bcd5672a.aspx)
     * 2. virtual: The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class
    */
    {
        protected override void Seed(ApplicationDbContext context)
        {
            SeedData(context);
        }

        public static void SeedData(ApplicationDbContext context)
        {
            //var barangays = new List<Barangay>
            
            new List<Barangay>
            {
                new Barangay { Name = "Caniogan", City ="Pasig", State= "NCR" },
                new Barangay { Name = "Maybunga", City ="Pasig", State= "NCR" },
                new Barangay { Name = "Rosario", City ="Pasig", State= "NCR" },
                new Barangay { Name = "Rosario", City ="Pateros", State= "NCR" },
                new Barangay { Name = "Sagad", City ="Pasig", State= "NCR" }
            }.ForEach(a => context.Barangays.AddOrUpdate(a));
            context.SaveChanges();
            
            //context.Setting.Add(new Setting { InitialScreen = 2 });

            new List<Title>
            {
                new Title { abbrTitle = "Ms.", fullTitle = "Miss"},
                new Title { abbrTitle = "Mrs.", fullTitle = "Mistress"},
                new Title { abbrTitle = "Mr.", fullTitle = "Mister"}
            }.ForEach(a => context.Titles.AddOrUpdate(a));
            context.SaveChanges();

            new List<Status>
            {
                new Status { StatusCode = "RV", Description = "Return Visit"},
                new Status { StatusCode = "S", Description = "Study"},
                new Status { StatusCode = "UP", Description = "Unbaptized Publisher"},
                new Status { StatusCode = "Int", Description = "Interested"}
            }.ForEach(a => context.Status.AddOrUpdate(a));
            context.SaveChanges();
            
            new List<Call>
            {
                new Call { Title = "Ms.", nameFirst = "Myla", nameLast = "San Luis", 
                    Street = "125 Dr. Sixto Antonio Av.", 
                    Barangay =  "Rosario",
                    City ="Pasig",
                    State = "NCR",
                    Phones = new Dictionary<string, string>() 
                    {
                        { "Mobile", "09181234567"},
                        { "Landline", "6420196"}
                    },
                    Email = new Dictionary<string, string>() 
                    {
                        { "Work", "mylasanluis@sanmiguel.com"},
                        { "Personal", "mylasanluis@gmail.com"}
                    },
                    dateFirstVisit = DateTime.Parse("10/01/2013", new System.Globalization.CultureInfo("en-US", false)),
                    dateLastVisit = DateTime.Parse("10/02/2013", new System.Globalization.CultureInfo("en-US", false)),
                    Status = "Interested",
                    Remarks = "Oct10'13: This girl is very interested. Worth returning to and offer a study"}, 
                
                new Call { Title = "Ms.", nameFirst = "Jimaymah", nameLast = "San Luis", 
                    Street = "125 NoWhere Av.", 
                    Barangay =  "Rosario",
                    City ="Pateros",
                    State = "NCR",
                    // See "How to: Initialize a Dictionary with a Collection Initializer": http://msdn.microsoft.com/en-us/library/vstudio/bb531208.aspx
                    Phones = new Dictionary<string, string>() 
                    {
                        { "Mobile", "09187654321"},
                        { "Landline", "6420196"}
                    },
                    Email = new Dictionary<string, string>() 
                    {
                        { "Work", "jimaymahsanluis@sanmiguel.com"},
                        { "Personal", "jimaymahsanluis@gmail.com"}
                    },
                    dateFirstVisit = DateTime.Parse("01/01/2013", new System.Globalization.CultureInfo("en-US", false)),
                    dateLastVisit = DateTime.Parse("05/02/2013", new System.Globalization.CultureInfo("en-US", false)),
                    Status = "Bible Study"},
                
                new Call { Title = "Mr.", nameFirst = "Jerry", nameLast = "Dela Cruz", 
                    Street = "125 NoWhere Av.", 
                    Barangay =  "Rosario",
                    City ="Pateros",
                    State = "NCR",
                    
                    dateFirstVisit = DateTime.Parse("01/01/2013", new System.Globalization.CultureInfo("en-US", false)),
                    dateLastVisit = DateTime.Parse("05/02/2013", new System.Globalization.CultureInfo("en-US", false)),
                    Status = "Interested"},
                
                new Call { Title = "Ms.", nameFirst = "Roselle", nameLast = "Valdez", 
                    Street = "69B Dr. Pilapil St.", 
                    Barangay =  "Sagad",
                    City ="Pasig",
                    State = "NCR",
                    dateFirstVisit = DateTime.Parse("12/01/2012", new System.Globalization.CultureInfo("en-US", false)),
                    dateLastVisit = DateTime.Parse("07/02/2013", new System.Globalization.CultureInfo("en-US", false)),
                    Status = "Unbaptized"},
                new Call { Title = "Mr.", nameFirst = "Danny", nameLast = "Reyes", 
                    Street = "24 Bernal St.", 
                    Barangay = "Maybunga",
                    City ="Pasig",
                    State = "NCR",
                    dateFirstVisit = DateTime.Parse("03/01/2013", new System.Globalization.CultureInfo("en-US", false)),
                    dateLastVisit = DateTime.Parse("06/02/2013", new System.Globalization.CultureInfo("en-US", false)), 
                    Status = "Bible Study"}
                
            }.ForEach(a => context.Calls.AddOrUpdate(a));
            context.SaveChanges();           
        }
    }
}
/*
 * It isn't necessary to call the  SaveChanges method after each group of entities, as is done here, but doing that helps
 * you locate the source of a problem if an exception occurs while the code is writing to the database.
 * http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
 */