﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BB_Practicum_API.Rules;
using BB_Practicum_API;
using System.Collections.Generic;
using System.Linq;

namespace BB_Practicum_Test
{
    [TestClass]
    public class UnitTestLogic
    {
        List<IDish> dishes;

        public UnitTestLogic()
        {
            dishes = new List<IDish>();
            dishes.Add(new Dish("morning", "eggs", 1, "entree", false));
            dishes.Add(new Dish("morning", "Toast", 2, "side", false));
            dishes.Add(new Dish("morning", "coffee", 3, "drink", true));

            dishes.Add(new Dish("night", "steak", 1, "entree", false));
            dishes.Add(new Dish("night", "potato", 2, "side", false));
            dishes.Add(new Dish("night", "wine", 3, "drink", true));
            dishes.Add(new Dish("night", "cake", 4, "dessert", false));
        }

        [TestMethod]
        public void TestLogic2xPotato()
        {
            var input = new[] { new { TypeId = 1 }, new { TypeId = 2 }, new { TypeId = 2 },  new { TypeId = 4 }  }.ToList();

            var timeofday = "night";

            var rs = input.GroupJoin(dishes, o => new { o.TypeId, TimeofDay = timeofday }, d => new { d.TypeId, d.TimeofDay },
                (o, d) => new Order { TypeId = o.TypeId, Dish = d.DefaultIfEmpty().FirstOrDefault() }).
                        OrderBy(t => t.TypeId).ToList<Order>();

            IRule[] rules = { };

            ILogic logic = new Logic(rs, rules);

            Assert.AreEqual(logic.Execute(), "steak, potato(x2), cake");
        }

        [TestMethod]
        public void TestLogic3xCoffee()
        {
            var input = new[] { new { TypeId = 1 }, new { TypeId = 2 }, new { TypeId = 3 }, new { TypeId = 3 }, new { TypeId = 3 } }.ToList();

            var timeofday = "morning";

            var rs = input.GroupJoin(dishes, o => new { o.TypeId, TimeofDay = timeofday }, d => new { d.TypeId, d.TimeofDay },
                (o, d) => new Order { TypeId = o.TypeId, Dish = d.DefaultIfEmpty().FirstOrDefault() }).
                        OrderBy(t => t.TypeId).ToList<Order>();

            IRule[] rules = { };

            ILogic logic = new Logic(rs, rules);

            Assert.AreEqual(logic.Execute(), "eggs, toast, coffee(x3)");
        }

    }
}
