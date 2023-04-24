using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.ResponseSchema
{
    public class LoginSchema
    {
        public static JSchema LoginJson()
        {
            JSchema schema = JSchema.Parse(@"{
    'type': 'object',
    'required': [
        'success',
        'token'
    ],
    'properties': {
        'success': {
            'type': 'boolean'
        },
        'token': {
            'type': 'string'
        }
    }
}");
            return schema;
        }
    }
}
