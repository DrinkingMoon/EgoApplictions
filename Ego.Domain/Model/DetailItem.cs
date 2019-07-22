using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class DetailItem : AggregateRoot
    {
        string _billNo;

        Product _product;

        Storage _storage;

        decimal _operationCount;

        string _batchNo;

        public string BillNo { get => _billNo; set => _billNo = value; }
        public virtual Product Product { get => _product; set => _product = value; }
        public virtual Storage Storage { get => _storage; set => _storage = value; }
        public decimal OperationCount { get => _operationCount; set => _operationCount = value; }
        public string BatchNo { get => _batchNo; set => _batchNo = value; }

    }
}
