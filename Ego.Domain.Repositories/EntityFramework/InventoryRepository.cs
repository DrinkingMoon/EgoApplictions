using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class InventoryRepository : RepositoryEntityFramework<Inventory>, IInventoryRepository
    {
        public InventoryRepository(IContext context) : base(context)
        {

        }

        public Inventory FindItem(Inventory inventory)
        {
            return GetItem(new Specifications.InventoryFromEntitySpecification(inventory));
        }
    }
}
