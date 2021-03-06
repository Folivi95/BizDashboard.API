﻿using BizDashboard.API.Models;
using System;
using System.Collections.Generic;

namespace BizDashboard.API.Data
{
    public class Helpers
    {
        private static Random _rand = new Random();

        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC", "XYZ",
            "Main St", "Sales", "Enterprise", "Ready", "Quick", "Budget", "Peak", "Magic",
            "Family", "Comfort"
        };

        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Corporation", "Co", "Logistics", "Transit", "Bakery", "Goods", "Foods", "Cleaners",
            "Hotels", "Planners", "Automotive", "Books"
        };

        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        internal static string MakeUniqueCustomerName(List<string> names)
        {
            var maxNames = bizPrefix.Count * bizSuffix.Count;

            if (names.Count >= maxNames)
            {
                throw new System.InvalidOperationException("Maximum number of unique names exceeded");
            }
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);

            var bizName = prefix + suffix;

            if (names.Contains(bizName))
            {
                MakeUniqueCustomerName(names);
            }

            return bizName;
        }

        internal static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newTimeSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

            return start + newTimeSpan;
        }

        internal static DateTime? GetRandomOrderCompleted(DateTime placed)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - placed;

            if (timePassed < minLeadTime)
            {
                return null;
            }

            return placed.AddHours(_rand.Next(7, 14));
        }

        internal static decimal GetRandomOrderTotal()
        {
            return (decimal)_rand.Next(100, 500);
        }

        internal static Customer GetRandomCustomer()
        {
            throw new NotImplementedException();
        }

        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";
        }

        internal static string GetRandomState()
        {
            return GetRandom(usStates);
        }

        private static readonly List<string> usStates = new List<string>()
        {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"
        };
    }
}
