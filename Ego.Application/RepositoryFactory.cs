using Ego.Domain;
using Ego.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Application
{
    public class RepositoryFactory
    {
        public static IRepository Repository<AggregateRoot, IRepository>(IContext ctx)
            where IRepository : Ego.Domain.IRepository<AggregateRoot>
            where AggregateRoot : Ego.Domain.AggregateRoot
        {
            return ServiceLocator.Instance.GetService<IRepository>(new KeyValuePair<string, object>("ctx", ctx));
        }

        public static IRepository Repository<AggregateRoot, IRepository>()
            where IRepository : Ego.Domain.IRepository<AggregateRoot>
            where AggregateRoot : Ego.Domain.AggregateRoot
        {
            return ServiceLocator.Instance.GetService<IRepository>(new KeyValuePair<string, object>("ctx", Context()));
        }

        public static IContext Context()
        {
            return ServiceLocator.Instance.GetService<IContext>();
        }
    }
}
