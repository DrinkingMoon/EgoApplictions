using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;
using Ego.Domain.Repositories;
using Ego.Domain.Repositories.EntityFramework;

namespace Ego.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EntityFrameworkRepositoryContext(new EgoDbContext()))
            {
                DishRepository dr = new DishRepository(ctx);
            }
        }
    }
}
