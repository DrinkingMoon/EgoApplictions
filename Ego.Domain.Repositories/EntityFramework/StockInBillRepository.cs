using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class StockInBillRepository : RepositoryEntityFramework<StockInBill>, IStockInBillRepository
    {
        public StockInBillRepository(IContext context) : base(context)
        {

        }

        public StockInBill FindItem(string billNo)
        {
            return GetItem(new Specifications.StockInBillFromBillNoSpecification(billNo));
        }
    }
}
