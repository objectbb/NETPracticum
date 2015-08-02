using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Practicum_API
{
    public class Dish : IDish
    {
        public Dish(string timeofday, string dish, int id, string dishtype, bool ismultiple)
        {
            TimeofDay = timeofday;
            Name = dish;
            TypeId = id;
            Type = dishtype;
            IsMultiple = ismultiple;
        }

        public string TimeofDay { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public bool IsMultiple { get; set; }
    }
}
