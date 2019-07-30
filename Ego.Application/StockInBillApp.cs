using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;
using Ego.Domain.Service;
using Ego.Domain.Repositories;
using Ego.Infrastructure.Transactions;
using Ego.Domain;
using Ego.Infrastructure;
using Ego.Domain.Events;

namespace Ego.Application
{
    public class StockInBillApp
    {
        static IContext _context = ServiceLocator.Instance.GetService<IContext>();
        static IStockInBillRepository _rep_StockInBill = ServiceLocator.Instance.GetService<IStockInBillRepository>(new KeyValuePair<string, object>("ctx", _context));
        static IInventoryRepository _rep_Inventory = ServiceLocator.Instance.GetService<IInventoryRepository>(new KeyValuePair<string, object>("ctx", _context));
        static IDomainService _service_Domain;
        static StockInBillEvent _event_StockInBill;

        public StockInBillApp()
        {
            _context = ServiceLocator.Instance.GetService<IContext>();

            _rep_StockInBill = ServiceLocator.Instance.GetService<IStockInBillRepository>
                (new KeyValuePair<string, object>("ctx", _context));

            _service_Domain = new Ego.Domain.Service.DomainService(_context, _rep_Inventory);
            _event_StockInBill = new Ego.Domain.Events.StockInBillEvent(_context, _rep_StockInBill, _service_Domain);

            //_service_Domain = ServiceLocator.Instance.GetService<IServiceDomain>
            //    (new KeyValuePair<string, object>("ctx", _context), 
            //    new KeyValuePair<string, object>("repInventory", _rep_Inventory));

            //_event_StockInBill = ServiceLocator.Instance.GetService<EventStockInBill>
            //    (new KeyValuePair<string, object>("ctx", _context),
            //    new KeyValuePair<string, object>("repStockInBill", _rep_StockInBill),
            //    new KeyValuePair<string, object>("service", _service_Domain));
        }

        public void Save(StockInBill bill)
        {
            _event_StockInBill.Save(bill);
        }

        public void Affrim(string billNo)
        {
            _event_StockInBill.Affirm(billNo);
        }

        public void Delete(string billNo)
        {
            _event_StockInBill.Delete(billNo);
        }
    }
}
