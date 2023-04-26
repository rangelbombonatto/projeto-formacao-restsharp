using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.ResponseSchema
{
    public class OrdersSchema
    {
        public static JSchema OrdersJson()
        {
            JSchema schema = JSchema.Parse(@"{
    'type': 'object',
    'required': [
        'total_discount',
        'status',
        '_meals',
        '_id',
        'total_amount',
        '_restaurant',
        'subtotal',
        '_user',
        'created_at',
        '__v'
    ],
    'properties': {
        'total_discount': {
            'type': 'number'
        },
        'status': {
            'type': 'string'
        },
        '_meals': {
            'type': 'array'
        },
        '_id': {
            'type': 'string'
        },
        'total_amount': {
            'type': 'number'
        },
        '_restaurant': {
            'type': 'string'
        },
        'subtotal': {
            'type': 'number'
        },
        '_user': {
            'type': 'string'
        },
        'created_at': {
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
