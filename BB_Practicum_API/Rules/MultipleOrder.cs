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

        public bool IsCorrect(IDish dish, int? pos = null)
        {

            List<int> duplist = new List<int>();

            rs.Take(pos.Value).Any(t =>
            {
                var item = t.Dish;

                if (item.Name.ToLower() == "coffee" || item.Name.ToLower() == "potato")
                    return false;

                duplist.Add(item.TypeId);

                return false;
            });

            return (duplist.Where(d => d == dish.TypeId).Count() > 0);
        }

    }
}
