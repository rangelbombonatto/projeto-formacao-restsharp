using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.ResponseSchema
{
    internal class RestaurantSchema
    {

        public static JSchema RestaurantJson()
        {
            JSchema schema = JSchema.Parse(@"{
    'type': 'object',
    'required': [
        '_meals',
        '_id',
        'name',
        'type',
        'description',
        '__v'
    ],
    'properties': {
        '_meals': {
            'type': 'array'
        },
        '_id': {
            'type': 'string'

        },
        'name': {
            'type': 'string'
        },
        'type': {
            'type': 'string'
        },
        'description': {
            'type': 'string'
        },
        '__v': {
            'type': 'integer'
        }
    }
}");
            return schema;
        }
    }
}
