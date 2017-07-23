using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TestFlatPlanet.DAL.Repository;

namespace TestFlatPlanet.Facade
{
    public class SqlServerFacade
    {
        private readonly SqlServerRepository _sqlServerRepository;
        public SqlServerFacade()
        {
            _sqlServerRepository = new SqlServerRepository(WebConfigurationManager.AppSettings["ConnectionString"]);
        }
        public bool CheckIfDatabaseExists()
        {
            return _sqlServerRepository.CheckIfDatabaseExists();
        }

        public void CreateDatabaseObjects()
        {
            _sqlServerRepository.CreateDatabaseObjects();
        }
    }
}