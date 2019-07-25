using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class RepStockInBill : RepositoryEntityFramework<StockInBill>, IRepStockInBill
    {
        public RepStockInBill(IContext ctx) : base(ctx)
        {

        }

        public StockInBill FindItem(string billNo)
        {
            return GetItem(new Specifications.SpecificationStockInBillFromBillNo(billNo));
        }
    }
}
