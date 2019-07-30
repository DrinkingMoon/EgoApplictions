using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class Restaurant : AggregateRoot
    {
        string _name;
        string _address;
        string _phoneNumber;
        ICollection<Dish> _dishes;

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public virtual ICollection<Dish> Dishes { get => _dishes; set => _dishes = value; }

        public Restaurant()
        { }

        public Restaurant(string name, string address, string phoneNumber, ICollection<Dish> dishes)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _dishes = dishes;
        }

        public Restaurant CreateNew()
        {
            return new Restaurant()
            {
                Name = this.Name,
                Address = this.Address,
                PhoneNumber = this.PhoneNumber,
                Dishes = this.Dishes == null ? new List<Dish>() : this.Dishes
            };
        }
    }
}
