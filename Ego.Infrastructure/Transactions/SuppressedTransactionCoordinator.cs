using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Infrastructure.Transactions
{
    internal sealed class SuppressedTransactionCoordinator : TransactionCoordinator
    {
        public SuppressedTransactionCoordinator(params IUnitOfWork[] unitOfWorks)
            : base(unitOfWorks)
        {
        }

    }
}
