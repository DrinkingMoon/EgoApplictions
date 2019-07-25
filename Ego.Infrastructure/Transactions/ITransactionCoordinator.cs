using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Infrastructure.Transactions
{
    public interface ITransactionCoordinator : IUnitOfWork, IDisposable
    {
    }
}
