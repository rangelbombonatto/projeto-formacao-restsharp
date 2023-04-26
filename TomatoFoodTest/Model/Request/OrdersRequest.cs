using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.Request
{
    public class OrdersRequest
    {
        public double total_amount { get; set; }

        public ArrayList _meals { get; set; }

        public string _restaurant { get; set; }

    }
}
