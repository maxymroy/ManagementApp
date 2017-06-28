using ManagementApp.DataContext;
using ManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Repositories
{
    public class FrequencyRepository
    {
        public IEnumerable<Frequency_> GetAllIndicators()
        {
            using (var DataContext = new mainEntities())
            {
                return DataContext.Frequency_.ToList();
            }
        }
    }
}