using Ego.Domain.Model;
using Ego.Domain.Service;
using Ego.Domain.Repositories;
using Ego.Infrastructure.Transactions;
using Ego.Domain.Events.Interface;

namespace Ego.Domain.Events
{
    public class StockInBillEvent : IStockInBillEvent
    {
        readonly IContext _context;
        readonly IDomainService _service_Domain;
        readonly IStockInBillRepository _rep_StockInBill;

        public StockInBillEvent
            (IContext ctx, 
            IStockInBillRepository repStockInBill, 
            IDomainService service)
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
