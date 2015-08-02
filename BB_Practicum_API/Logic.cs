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

                   bool anyerrors = rules.Any((r) => r.IsBroken(t.Dish, pos));

                   if (anyerrors) return "error";

                   return t.Dish.Name.ToLower();

               }).GroupBy(v => v).Select(t =>
                {
                    return (t.Count() > 1 && t.Key != "error") ? String.Format("{0}(x{1})", t.Key, t.Count()) : t.Key;
                }).ToList<string>();


            var sb = new StringBuilder();
            output.FirstOrDefault(t =>
                {
                    sb.Append(t + ", ");

                    if (t == "error") return true;

                    return false;
                });

            return sb.ToString().TrimEnd(' ', ',');
        }
   
    }
}
