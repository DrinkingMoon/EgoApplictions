using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class Product :AggregateRoot
    {
        string _name;
        string _code;
        string _spec;
        string _productType;

        public string Name { get => _name; set => _name = value; }
        public string Code { get => _code; set => _code = value; }
        public string Spec { get => _spec; set => _spec = value; }
        public string Producttype { get => _productType; set => _productType = value; }

        public Product() { }

        public Product(string name, string code, string spec, string productType)
        {
            _name = name;
            _code = code;
            _spec = spec;
            _productType = productType;
        }
    }
}
