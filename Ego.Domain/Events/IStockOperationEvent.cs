using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Events
{
    public interface IStockOperationEvent
    {
        void StockIn<T>(Guid billID) where T : class, IAggregateRoot;
    }
}
