using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;

namespace Ego.Domain.Service
{
    public class DomainService : IDomainService
    {
        readonly Ego.Domain.Repositories.IInventoryRepository _rep_Inventory;
        public DomainService()
        {

        }

        public void StockOperation(Inventory inventory)
        {
            if (inventory == null || inventory.StockQty == 0)
            {
                return;
            }

            Inventory inv = _rep_Inventory.FindItem(inventory.Product, inventory.BatchNo, inventory.Storage);

            if (inv == null && inventory.StockQty > 0)
            {
                _rep_Inventory.Add(inventory.CreateNew());
            }
            else
            {
                inv.OperationStockQty(inventory.StockQty);
            }
        }
    }
}
