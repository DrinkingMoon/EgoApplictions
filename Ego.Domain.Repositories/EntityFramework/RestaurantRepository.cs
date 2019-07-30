using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class RestaurantRepository : RepositoryEntityFramework<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(IContext context) : base(context)
        {
        }
    }
}
