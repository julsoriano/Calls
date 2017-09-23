using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Calls.Models;

namespace Calls
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {    
            Action seedDB = delegate() { SeedDB();} ;
            seedDB();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        #region Create and seeed the database
        static void SeedDB()
        {
            System.Data.Entity.Database.SetInitializer(new Calls.Models.SampleData());

            // Runs the registered IDatabaseInitializer<TContext> on this context. 
            // If the parameter force is set to true, then the initializer is run regardless of whether or not it has been run before. 
            // This can be useful if a database is deleted while an app is running and needs to be reinitialized.            
            //    
            using (var context = new Calls.Models.ApplicationDbContext())
            {
                try
                {
                    if (context.Database.Exists())
                        context.Database.Delete();

                    context.Database.Create();
                    // Warning!!!: Next statement will not work if disableDatabaseInitialization="false" in section <context> in web.config
                    context.Database.Initialize(force: true);                    
                }
                catch (SqlException ex)
                {
                    DisplaySqlErrors(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }

            }
        }

        private static void DisplaySqlErrors(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                Console.WriteLine("Index #" + i + "\n" +
                    "Error: " + exception.Errors[i].ToString() + "\n");
            }
            Console.ReadLine();
        }
        #endregion

    }
}
