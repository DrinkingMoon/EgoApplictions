using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;
using Ego.Domain.Specifications;

namespace Ego.Domain.Repositories.Specifications
{
    internal class StockInBillFromBillNoSpecification : Specification<StockInBill>
    {
        readonly string _billNo;

        public StockInBillFromBillNoSpecification(string billNo)
        {
            _billNo = billNo;
        }

        public override Expression<Func<StockInBill, bool>> GetExpression()
        {
            return k => k.BillNo == _billNo;
        }
    }
}
