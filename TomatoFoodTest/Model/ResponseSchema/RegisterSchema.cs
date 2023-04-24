using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.ResponseSchema
{
    internal class RegisterSchema
    {
        public static JSchema RegisterJson()
        {
            JSchema schema = JSchema.Parse(@"{
    'type': 'object',
    'required': [
        'role',
        '_id',
        'name',
        'email',
        'password',
        'date',
        '__v'
    ],
    'properties': {
        'role': {
            'type': 'string'
        },
        '_id': {
            'type': 'string'
        },
        'name': {
            'type': 'string'
        },
        'email': {
            'type': 'string'
        },
        'password': {
            'type': 'string'
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
