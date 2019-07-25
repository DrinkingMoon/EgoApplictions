using Ego.Domain.Model;
using Ego.Domain.Service;
using Ego.Domain.Repositories;
using Ego.Infrastructure.Transactions;
using Ego.Domain.Events.Interface;

namespace Ego.Domain.Events
{
    public class EventStockInBill : IEventStockInBill
    {
        readonly IContext _context;
        readonly IServiceDomain _service_Domain;
        readonly IRepStockInBill _rep_StockInBill;

        public EventStockInBill
            (IContext ctx, 
            IRepStockInBill repStockInBill, 
            IServiceDomain service)
        {
            _context = ctx;
            _service_Domain = service;
            _rep_StockInBill = repStockInBill;
        }

        public void Save(StockInBill billInfo)
        {
            StockInBill tempBill = _rep_StockInBill.FindItem(billInfo.BillNo);

            if (tempBill != null)
            {
                _rep_StockInBill.Update(tempBill);
            }
            else
            {
                _rep_StockInBill.Insert(billInfo);
            }

            _context.Commit();
        }

        public void Affirm(string billNo)
        {
            StockInBill billInfo = _rep_StockInBill.FindItem(billNo);
            billInfo.Affirm();

            foreach (StockInItem item in billInfo.StockInItems)
            {
                _service_Domain.StockOperation(item.ConvertToInventory());
            }

            _context.Commit();
        }

        public void Delete(string billNo)
        {
            StockInBill billInfo = _rep_StockInBill.FindItem(billNo);
            _rep_StockInBill.Delete(billInfo);
            _context.Commit();
        }
    }
}
