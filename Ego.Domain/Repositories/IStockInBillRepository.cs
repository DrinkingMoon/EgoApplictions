using Ego.Domain.Model;
using Ego.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories
{
    public interface IStockInBillRepository : IRepository<StockInBill>
    {
        StockInBill FindItem(string billNo);
    }
}
