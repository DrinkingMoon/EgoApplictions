using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class RepUser : RepositoryEntityFramework<User>, IRepUser
    {
        public RepUser(IContext context) : base(context)
        {
        }
    }
}
