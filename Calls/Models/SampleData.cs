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
                new Barangay { Name = "Bagong-Ilog", City ="Pasig", State= "NCR" },
                new Barangay { Name = "Ugong", City ="Pateros", State= "NCR" },
            }.ForEach(a => context.Barangays.AddOrUpdate(a));

            /*
             * It isn't necessary to call the  SaveChanges method after each group of entities, as is done here, but doing that helps
             * you locate the source of a problem if an exception occurs while the code is writing to the database.
             * http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
             */
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
                new Call { Title = "Ms.", nameFirst = "Shen", nameLast = "Comia", 
                    Street = "N. Espiritu St. (off DSAA)", 
                    Barangay =  "Caniogan",
                    City ="Pasig",
                    State = "NCR",
                    /* See "How to: Initialize a Dictionary with a Collection Initializer": http://msdn.microsoft.com/en-us/library/vstudio/bb531208.aspx
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
                     * */
                    dateFirstVisit = DateTime.Parse("11/29/2013", new System.Globalization.CultureInfo("en-US", false)),
                    dateLastVisit = DateTime.Parse("12/28/2013", new System.Globalization.CultureInfo("en-US", false)),
                    Status = "RV",
                    Remarks = "29Nov'13: about 25-10 y.o. Looks smart. Owns a flat at Mezza I which she doesn't like. With Robbie." + System.Environment.NewLine +
                    "28Dec'13: NH; Left 'Book For All Mankind '"}, 
                
                new Call { Title = "Mr.", nameFirst = "Raffy", nameLast = "Santiago", 
                    Street = "Algarra-Bernardo Cpd., C. Santos St.", 
                    Barangay =  "Ugong",
                    City ="Pasig",
                    State = "NCR",
                    dateFirstVisit = DateTime.Parse("09/03/2013", new System.Globalization.CultureInfo("en-US", false)),
                    dateLastVisit = DateTime.Parse("09/10/2013", new System.Globalization.CultureInfo("en-US", false)),
                    Status = "Int",
                    Remarks = "03Sep'13: Seems interested. Discuss 'How to find the true religion'. Finding it is a lot of common sense, like finding a true friend. With Serafin." + System.Environment.NewLine +
                    "07Sep'13: Had a short discussion. Tells me to come back Tue., 10Sep.'" + System.Environment.NewLine +
                    "10Sep'13: Discussed why peace is elusive: We're living in the end. Promising prospect"}, 
                
            }.ForEach(a => context.Calls.AddOrUpdate(a));
            context.SaveChanges();           
        }
    }
}