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
            return rs.Take(pos.Value).Any(t =>
                (t.Dish.Name.ToLower() != "coffee" || t.Dish.Name.ToLower() != "potato") && t.Dish.TypeId == dish.TypeId);
        }

    }
}
