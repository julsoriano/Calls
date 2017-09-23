using System.Web;
using System.Web.Mvc;

namespace Calls
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            /*
             * From "Securing your ASP.NET MVC 4 App and the new AllowAnonymous Attribute"
             * http://blogs.msdn.com/b/rickandy/archive/2012/03/23/securing-your-asp-net-mvc-4-app-and-the-new-allowanonymous-attribute.aspx
             * -----------------------------------------------------------------------------------------------------------------------------
             * "ASP.NET MVC 3 introduced global filters, which allows you to add the AuthorizeAttribute filter to the global.asax file 
             * to protect every action method of every controller.
             * 
             * ... the AuthorizeAttribute applied in global.asax can be use (sic) to ensure all methods are authorized 
             * (except those explicitly white listed with the AllowAnonymous attribute."
             */
            filters.Add(new AuthorizeAttribute());
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}
