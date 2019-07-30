using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;
using Ego.Domain.Repositories;

namespace Ego.Domain.Service
{
    public class DomainService : IDomainService
    {
        readonly IContext _context;
        readonly IInventoryRepository _rep_Inventory;

        public DomainService(IContext ctx, IInventoryRepository repInventory)
        {
            this._context = ctx;
            this._rep_Inventory = repInventory;
        }

        public void StockOperation(Inventory inventory)
        {
            if (inventory == null || inventory.StockQty == 0)
            {
                return;
            }

            Inventory inv = _rep_Inventory.FindItem(inventory);

            if (inv == null && inventory.StockQty > 0)
            {
                _rep_Inventory.Insert(inventory.CreateNew());
            }
            else
            {
                inv.OperationStockQty(inventory.StockQty);
                _rep_Inventory.Update(inv);
            }

            _context.Commit();
        }
    }
}
