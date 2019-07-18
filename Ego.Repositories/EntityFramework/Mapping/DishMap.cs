
using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Repositories.EntityFramework.Mapping
{
    public class DishMap : EntityTypeConfiguration<Dish>
    {
        public DishMap()
        {

        }
    }
}
