using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Repositories;
using Ego.Domain;
using Ego.Domain.Model;

namespace Ego.Domain.Events
{
    public class StockOperation : IStockOperationEvent
    {
        readonly IRepositoryContext _repositoryContext;

        readonly Ego.Domain.Repositories.IStockInBillRepository _stockInBillRepository;
        readonly Ego.Domain.Repositories.IInventoryRepository _inventoryRepository;

        public StockOperation()
        {

        }

        public void StockIn<T>(Guid billID) where T:class, IAggregateRoot
        {
            var bill
            switch (typeof(T).Name)
            {
                case typeof(StockInBill).Name:
                    bill = _stockInBillRepository.GetItem(billID);
                    break;
                default:
                    break;
            }

        }
    }
}
