using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class RepStorage : RepositoryEntityFramework<Storage>, IRepStorage
    {
        public RepStorage(IContext context) : base(context)
        {

        }
    }
}
