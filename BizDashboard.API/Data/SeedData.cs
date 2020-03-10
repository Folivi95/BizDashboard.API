using BizDashboard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!this.ctx.Customers.Any())
            {
                SeedCustomers(nCustomers);
            }

            if (!this.ctx.Orders.Any())
            {
                SeedOrders(nCustomers);
            }

            if (!this.ctx.Servers.Any())
            {
                SeedServers();
            }

            this.ctx.SaveChanges();
        }

        private void SeedCustomers(int n)
        {
            List<Customer> customers = BuildCustomerList(n);

            foreach (var customer in customers)
            {
                this.ctx.Customers.Add(customer);
            }
        }

        public void SeedOrders(int n)
        {
            List<Order> orders = BuildOrderList(n);

            foreach (var order in orders)
            {
                this.ctx.Orders.Add(order);
            }
        }

        private List<Order> BuildOrderList(int n)
        {
            var orders = new List<Order>();
            var rand = new Random();

            for (int i = 0; i < n; i++)
            {
                var placed = Helpers.GetRandomOrderPlaced();
                var completed = Helpers.GetRandomOrderCompleted(placed);

                var randCustomerId = rand.Next(this.ctx.Customers.Count());

                orders.Add(new Order
                {
                    Id = i,
                    Customer = this.ctx.Customers.First(c => c.Id == randCustomerId),
                    Total = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }

            return orders;
        }

        public void SeedServers()
        {
            List<Server> servers = BuildServerList();

            foreach (var server in servers)
            {
                this.ctx.Servers.Add(server);
            }
        }

        private List<Server> BuildServerList()
        {
            return new List<Server>()
            {
                new Server
                {
                    Id = 1,
                    Name = "Dev-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id = 2,
                    Name = "Dev-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 3,
                    Name = "Dev-Services",
                    IsOnline = false
                },
                new Server
                {
                    Id = 4,
                    Name = "QA-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id = 5,
                    Name = "QA-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 6,
                    Name = "Qa-Services",
                    IsOnline = false
                },
                new Server
                {
                    Id = 7,
                    Name = "Prod-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id = 8,
                    Name = "Prod-Mail",
                    IsOnline = false,
                },
                new Server
                {
                    Id = 9,
                    Name = "Prod-Services",
                    IsOnline = true
                },
            };
        }

        private List<Customer> BuildCustomerList(int nCustomers)
        {
            var customers = new List<Customer>();
            var names = new List<string>();

            for (int i = 0; i < nCustomers; i++)
            {
                var name = Helpers.MakeUniqueCustomerName(names);
                names.Add(name);

                customers.Add(new Customer
                {
                    Id = i,
                    Name = name,
                    Email = Helpers.MakeCustomerEmail(name),
                    State = Helpers.GetRandomState()
                });
            }

            return customers;
        }
    }
}
