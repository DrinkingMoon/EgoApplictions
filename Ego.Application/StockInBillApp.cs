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
        static IRepStockInBill _rep_StockInBill = ServiceLocator.Instance.GetService<IRepStockInBill>(new KeyValuePair<string, object>("ctx", _context));
        static IRepInventory _rep_Inventory = ServiceLocator.Instance.GetService<IRepInventory>(new KeyValuePair<string, object>("ctx", _context));
        static IServiceDomain _service_Domain;
        static EventStockInBill _event_StockInBill;

        public StockInBillApp()
        {
            _context = ServiceLocator.Instance.GetService<IContext>();

            _rep_StockInBill = ServiceLocator.Instance.GetService<IRepStockInBill>
                (new KeyValuePair<string, object>("ctx", _context));

            _service_Domain = new Ego.Domain.Service.ServiceDomain(_context, _rep_Inventory);
            _event_StockInBill = new Ego.Domain.Events.EventStockInBill(_context, _rep_StockInBill, _service_Domain);

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
