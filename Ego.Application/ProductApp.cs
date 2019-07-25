using Ego.Domain;
using Ego.Domain.Events.Interface;
using Ego.Domain.Model;
using Ego.Domain.Repositories;
using Ego.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Infrastructure.Transactions;

namespace Ego.Application
{
    public class ProductApp
    {
        static readonly IContext _context = RepositoryFactory.EFDbContextEgo();
        static readonly IRepProduct _rep_Product = RepositoryFactory.Repository<Product, IRepProduct>(_context);
        static readonly IEventProduct _event_Product = new Ego.Domain.Events.EventProduct(_context, _rep_Product);

        public ProductApp()
        {
            //_context = ServiceLocator.Instance.GetService<IContext>();
            //_rep_Product = ServiceLocator.Instance.GetService<IRepProduct>(new KeyValuePair<string, object>("ctx", _context));
            //_event_Product = new Ego.Domain.Events.EventProduct(_context, _rep_Product);
        }

        public void Save(Product product)
        {
            //_context = ServiceLocator.Instance.GetService<IContext>();

            using (ITransactionCoordinator tran = TransactionCoordinatorFactory.Create(_context))
            {
                _event_Product.Save(product);
                tran.Commit();
            }
        }
    }
}
