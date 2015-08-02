using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Practicum_API.Rules
{
    public class DesertMorningMeals : IRule
    {
        public bool IsCorrect(IDish dish, int? pos = null) 
        {
            return (dish.TypeId == 4 && dish.TimeofDay == "night");
        }
        
    }
}
