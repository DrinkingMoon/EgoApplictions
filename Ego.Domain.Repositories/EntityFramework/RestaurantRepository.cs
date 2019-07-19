using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class RestaurantRepository : EntityFrameworkRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(IRepositoryContext context) : base(context) { }
    }
}
