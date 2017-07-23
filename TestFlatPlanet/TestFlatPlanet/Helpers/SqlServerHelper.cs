using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TestFlatPlanet.Facade;

namespace TestFlatPlanet.Helpers
{
    public static class SqlServerHelper
    {
        public static void Initialize()
        {
            //instantiate repository
            SqlServerFacade facade = new SqlServerFacade();

            //Check if repository is available
            if (!facade.CheckIfDatabaseExists())
            {
                facade.CreateDatabaseObjects();
            }
        }
    }
     
}