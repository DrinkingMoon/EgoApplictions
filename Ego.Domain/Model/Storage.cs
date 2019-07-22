using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class Storage : AggregateRoot
    {
        public string Name { get; set; }

        //string _name;

        //public string Name { get => _name; set => _name = value; }

        //public Storage() { }

        //public Storage(string name)
        //{
        //    _name = name;
        //}
    }
}
