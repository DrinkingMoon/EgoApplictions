using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Infrastructure;
using Ego.Domain;
using Ego.Domain.Model;
using Ego.Domain.Repositories;

namespace Ego.Domain.Service
{
    public class Test
    {
        public void TestApp()
        {
            using (RepositoryContext ctx = ServiceLocator.Instance.GetService<RepositoryContext>())
            {
                IStorageRepository isP =
                    ServiceLocator.Instance.GetService<IStorageRepository>(new Dictionary<string, object>() { { "ctx", ctx } });

                Storage storage = new Storage()
                {
                    Name = "产成品库房"
                };

                isP.Add(storage);
                ctx.Commit();
            }
        }
    }
}
