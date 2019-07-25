using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;
using Ego.Domain.Specifications;

namespace Ego.Domain.Repositories.Specifications
{
    internal class SpecificationInventoryFromEntity : Specification<Inventory>
    {
        readonly Inventory _inventory;
        public SpecificationInventoryFromEntity(Inventory inventory)
        {
            _inventory = inventory;
        }
        public override Expression<Func<Inventory, bool>> GetExpression()
        {
            return k => k.BatchNo == _inventory.BatchNo 
            && k.Product == _inventory.Product
            && k.Storage == _inventory.Storage;
        }
    }
}
