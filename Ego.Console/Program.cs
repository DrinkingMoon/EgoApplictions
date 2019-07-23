using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain;
using Ego.Domain.Model;
using Ego.Domain.Repositories;
//using Ego.Infrastructure;
//using Ego.Domain.Repositories.EntityFramework;

namespace Ego.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage
            {
                Name = "原材料库房"
            };

            //using (EntityFrameworkRepositoryContext ctx = new EntityFrameworkRepositoryContext(new Domain.Repositories.EntityFramework.EgoDbContext()))
            //{
            //    StorageRepository sp = new StorageRepository(ctx);

            //    sp.Add(storage);
            //}

            //var dbContext = ServiceLocator.Instance.GetService<IRepositoryContext>
            //    (new Dictionary<string, object>() { { "dbContext", new EgoDbContext() } });
            //var ctx = ServiceLocator.Instance.GetService<IStorageRepository>
            //    (new Dictionary<string, object>() { { "ctx", dbContext } });

            //ctx.Add(storage);
            //dbContext.Commit();

            new Ego.Domain.Service.Test().TestApp();

            Console.ReadKey();
        }
    }
}
