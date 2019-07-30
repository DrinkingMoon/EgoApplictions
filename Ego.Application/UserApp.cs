using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Ego.Domain;
using Ego.Domain.Model;
using Ego.Domain.Repositories;
using Ego.Domain.Service;
using Ego.Domain.Events;
using Ego.Domain.Events.Interface;

namespace Ego.Application
{
    public class UserApp
    {
        static IContext _context = RepositoryFactory.EFDbContextUser();
        static IUserRepository _rep_User = RepositoryFactory.Repository<User, IUserRepository>(_context);
        IUserEvent _event_User = new UserEvent(_context, _rep_User);

        public UserApp()
        {

        }

        public void Save(User user)
        {
            _event_User.Save(user);
        }
    }
}
