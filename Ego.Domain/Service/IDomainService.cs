using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Service
{
    public interface IDomainService
    {
        void StockOperation(Ego.Domain.Model.Inventory inventory);
    }
}
