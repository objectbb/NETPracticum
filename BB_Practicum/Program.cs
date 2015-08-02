using BB_Practicum_API;
using BB_Practicum_API.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Practicum
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputarray = args;

            if(String.IsNullOrEmpty(inputarray[0])){
                Console.WriteLine("Wrong input i.e. morning,1,2,3");
                return;
            }

            var timeofday = inputarray[0].TrimEnd(',').ToLower();
            var orders = inputarray.Skip(1).Select(t => { return new { TypeId = int.Parse(t.TrimEnd(',')) }; }).ToList();

            //var orders = new[] { new { TypeId = 1 }, new { TypeId = 1 }, new { TypeId = 2 }, new { TypeId = 3 }, new { TypeId = 5 } }.ToList();

            List<IDish> dishes = new List<IDish>();
            dishes.Add(new Dish("morning", "eggs", 1, "entree", false));
            dishes.Add(new Dish("morning", "Toast", 2, "side", false));
            dishes.Add(new Dish("morning", "coffee", 3, "drink", true));

            dishes.Add(new Dish("night", "steak", 1, "entree", false));
            dishes.Add(new Dish("night", "potato", 2, "side", false));
            dishes.Add(new Dish("night", "wine", 3, "drink", true));
            dishes.Add(new Dish("night", "cake", 4, "dessert", false));

            var rs = orders.GroupJoin(dishes, o => new { o.TypeId, TimeofDay = timeofday }, d => new { d.TypeId, d.TimeofDay },
                (o, d) => new Order { TypeId = o.TypeId, Dish = d.DefaultIfEmpty().FirstOrDefault() }).
                        OrderBy(t => t.TypeId).ToList<Order>();

            IRule[] rules = { new MultipleOrder(rs), new DesertMorningMeals()};

            int pos = 0;
            var output = rs.Select(t =>
            {
                if (t.Dish == null)
                {
                    // Console.Write("error");
                    // return true;

                    return "error";
                }

                var anyerrors = rules.TakeWhile((r, index) => !String.IsNullOrEmpty(r.ReturnMsg(t.Dish, pos)));
                pos++;

                if (anyerrors.Count() > 0)
                {
                    return "error";
                }

                //Console.Write(t.Dish.Name.ToLower());

                return t.Dish.Name.ToLower();
                // return false;

            }).ToArray<string>();

            Console.Write(String.Join(", ",output));


        }
    }
}
