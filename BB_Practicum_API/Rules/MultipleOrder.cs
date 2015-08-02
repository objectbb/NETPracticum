using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Practicum_API.Rules
{
    public class MultipleOrder : IRule
    {
        private List<Order> rs;
  
        public MultipleOrder(List<Order> rs)
        {
            this.rs = rs;
        }

        public string ReturnMsg(IDish dish, int? pos = null)
        {

            List<int> duplist = new List<int>();

            rs.Take(pos.Value).Any(t =>
            {
                var item = t.Dish;

                if (t.Dish.Name.ToLower() == "coffee" || t.Dish.Name.ToLower() == "potato")
                    return false;

                duplist.Add(t.Dish.TypeId);

                return false;
            });

            return (duplist.Where(d => d == dish.TypeId).Count() > 1) ? "error" : String.Empty;
        }

    }
}
