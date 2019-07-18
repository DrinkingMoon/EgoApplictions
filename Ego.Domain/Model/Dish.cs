using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{

    public class Dish : AggregateRoot
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Comment { get; set; }


        public double? Score { get; set; }

        public string FKID_Restaurant { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
