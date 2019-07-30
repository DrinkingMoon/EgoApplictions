using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ego.Domain;
using Ego.Domain.Model;
using Ego.Domain.Repositories;
using Ego.Domain.Service;
using Ego.Domain.Events;
using Ego.Domain.Events.Interface;

namespace Ego.Domain.Events
{
    public class ProductEvent : IProductEvent
    {
        readonly IContext _context;
        readonly IProductRepository _rep_Product;

        public ProductEvent(IContext ctx, IProductRepository repProduct)
        {
            _context = ctx;
            _rep_Product = repProduct;
        }

        public void Save(Product product)
        {
            Product tempInfo = _rep_Product.FindItem(product);
            //_rep_Product.GetItem(Specifications.Specification<Product>.Eval(k => k.ID == product.ID));

            if (tempInfo == null)
            {
                _rep_Product.Insert(product);
            }
            else
            {
                _rep_Product.Update((Product)tempInfo.Cover(product));
            }

            _context.Commit();
        }
    }
}
