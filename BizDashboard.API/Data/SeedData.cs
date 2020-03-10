using BizDashboard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizDashboard.API.Data
{
    public class SeedData
    {
        private readonly ApiContext ctx;

        public SeedData(ApiContext ctx)
        {
            this.ctx = ctx;
        }

        public void DataSeed(int nCustomers, int nOrders)
        {
            if (this.ctx.Customers.Any())
            {
                SeedCustomers(nCustomers);
            }

            if (this.ctx.Orders.Any())
            {
                SeedOrders(nCustomers);
            }

            if (this.ctx.Servers.Any())
            {
                SeedServers(nCustomers);
            }

            this.ctx.SaveChanges();
        }
    }
}
