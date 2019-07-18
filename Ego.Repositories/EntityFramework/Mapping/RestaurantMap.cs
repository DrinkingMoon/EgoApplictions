
using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Mapping
{
    public class RestaurantMap : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantMap()
        {

        }
    }
}
