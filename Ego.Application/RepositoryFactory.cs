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
        static IContext _context;

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
            return ServiceLocator.Instance.GetService<IRepository>(new KeyValuePair<string, object>("ctx", _context));
        }

        public static IContext DbContext(string name)
        {
            _context = ServiceLocator.Instance.GetService<IContext>(name);
            return _context;
        }

        public static IContext EFDbContextEgo()
        {
            _context = ServiceLocator.Instance.GetService<IContext>("EFDbContextEgo");
            return _context;
        }
    }
}
