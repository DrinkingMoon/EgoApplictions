using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class Inventory : AggregateRoot
    {
        Product _product;

        decimal _stockQty;

        string _batchNo;

        Storage _storage;

        DateTime _entryTime;

        public decimal StockQty { get => _stockQty; set => _stockQty = value; }
        public string BatchNo { get => _batchNo; set => _batchNo = value; }
        public DateTime EntryTime { get => _entryTime; set => _entryTime = value; }
        public virtual Product Product { get => _product; set => _product = value; }
        public virtual Storage Storage { get => _storage; set => _storage = value; }



        public Inventory() { }
        public Inventory(Product product, string batchNo, decimal stockQty, Storage storage,  DateTime entryTime)
        {
            _entryTime = entryTime;
            _batchNo = batchNo;
            _stockQty = stockQty;

            _product = product;
            _storage = storage;
        }

        public Inventory CreateNew()
        {
            return new Inventory(this.Product, this.BatchNo, this.StockQty, this.Storage, DateTime.Now);
        }

        public void OperationStockQty(decimal operationCount)
        {
            this.StockQty += operationCount;
        }
    }
}
