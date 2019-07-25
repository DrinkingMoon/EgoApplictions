using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class RepInventory : RepositoryEntityFramework<Inventory>, IRepInventory
    {
        public RepInventory(IContext ctx) : base(ctx)
        {

        }

        public Inventory FindItem(Inventory inventory)
        {
            return GetItem(new Specifications.SpecificationInventoryFromEntity(inventory));
        }
    }
}
