using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class Dish : IEntity
    {
        Guid _id;

        string _name;

        string _category;

        string _comment;

        double? _scorce;

        Restaurant _restaurant;

        public virtual Restaurant Restaurant { get => _restaurant; set => _restaurant = value; }
        public double? Scorce { get => _scorce; set => _scorce = value; }
        public string Comment { get => _comment; set => _comment = value; }
        public string Category { get => _category; set => _category = value; }
        public string Name { get => _name; set => _name = value; }
        public Guid ID { get => _id; set => _id = value; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (!(obj is Dish dish))
            {
                return false;
            }

            return this.ID == dish.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
