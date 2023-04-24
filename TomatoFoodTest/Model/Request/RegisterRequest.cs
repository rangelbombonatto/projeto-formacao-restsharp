using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.Request
{
    public class RegisterRequest
    {
        public string email { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public string password2 { get; set; }

        public string role { get; set; }
    }
}
