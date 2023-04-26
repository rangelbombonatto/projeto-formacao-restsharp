using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.Request
{
    public class RestaurantRequest
    {
        public string name { get; set; }

        public string description { get; set; }

        public string type { get; set; }

        public List<Meal> _meals { get; set; }
    }

    public class Meal
    {
        public string description { get; set; }
        public string name { get; set; }
        public string price { get; set; }
    }
}
