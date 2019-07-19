using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{

    public class Dish : ModelRoot
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Comment { get; set; }

        public double? Score { get; set; }


        public Guid? FK_Restaurant { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
