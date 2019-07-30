using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class StorageRepository : RepositoryEntityFramework<Storage>, IStorageRepository
    {
        public StorageRepository(IContext context) : base(context)
        {

        }
    }
}
