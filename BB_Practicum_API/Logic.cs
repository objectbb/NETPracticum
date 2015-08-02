using BB_Practicum_API.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Practicum_API
{
    public class Logic : BB_Practicum_API.ILogic
    {
        List<Order> order;
        IRule[] rules;

        public Logic(List<Order> order, IRule[] rules)
        {
            this.order = order;
            this.rules = rules;
        }

        public string Execute()
        {
            var output = order.Select((t, pos) =>
               {
                   if (t.Dish == null) return "error";

                   var anyerrors = rules.TakeWhile((r, index) => !String.IsNullOrEmpty(r.ReturnMsg(t.Dish, pos)));

                   if (anyerrors.Count() > 0) return "error";

                   return t.Dish.Name.ToLower();

               }).ToArray<string>();

            return String.Join(", ", output);
        }
    }
}
