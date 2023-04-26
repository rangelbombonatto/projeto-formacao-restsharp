using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.ResponseSchema
{
    public class AboutSchema
    {

            public static JSchema AboutJson()
            {
                JSchema schema = JSchema.Parse(@"{
    'type': 'object',
    'required': [
        'about',
        'name',
        'email',
        'open',
        'date',
        '__v'
    ],
    'properties': {
        'about': {
            'type': 'string'
        },
        'name': {
            'type': 'string'
        },
        'email': {
            'type': 'string'
        },
        'open': {
            'type': 'boolean'
        },
        'date': {
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
