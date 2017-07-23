using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TestFlatPlanet.DAL.Repository;

namespace TestFlatPlanet.Facade
{
    public class CounterFacade
    {

        private readonly CounterRepository _counterRepository;
        public CounterFacade()
        {
            _counterRepository = new CounterRepository(WebConfigurationManager.AppSettings["ConnectionString"]);
        }

        public int GetCount()
        {
            return _counterRepository.GetCount();
        }

        public bool UpdateCount()
        {
            var currentCount = this.GetCount();
            if (currentCount < 10)
            {
                _counterRepository.UpdateCount();
                return true;
            }
            else
                return false;
        }
    }
}