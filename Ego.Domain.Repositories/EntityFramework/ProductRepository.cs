using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class ProductRepository : RepositoryEntityFramework<Product>, IProductRepository
    {
        public ProductRepository(IContext context) : base(context)
        {

        }

        public Product FindItem(Product product)
        {
            return GetItem(Ego.Domain.Specifications.Specification<Product>.Eval(k => 
            k.Name == product.Name && 
            k.Code == product.Code && 
            k.Spec == product.Spec));
        }
    }
}
