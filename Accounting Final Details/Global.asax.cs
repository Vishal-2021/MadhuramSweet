using Accounting_Final_Details.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Accounting_Final_Details
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // here set database initializer after model change table will drop

          



          //   Database.SetInitializer<AccountDetailsDBContext>(null);
             
             

            //  Database.SetInitializer<AccountDetailsDBContext>(new DBInitializer());

            //  Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());

        }
    }
}
