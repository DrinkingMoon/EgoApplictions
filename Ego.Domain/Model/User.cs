using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class User : AggregateRoot
    {
        string _name;
        string _department;
        int _age;
        string workID;

        public string Name { get => _name; set => _name = value; }
        public string Department { get => _department; set => _department = value; }
        public int Age { get => _age; set => _age = value; }
        public string WorkID { get => workID; set => workID = value; }

        public User()
        {

        }

        public User(string name, string department, int age, string workID)
        {
            this.Name = name;
            this.Department = department;
            this.Age = age;
            this.WorkID = workID;
        }


    }
}
