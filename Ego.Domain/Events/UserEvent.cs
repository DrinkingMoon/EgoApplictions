
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

namespace Ego.Domain.Events
{
    public class UserEvent : IUserEvent
    {
        IContext _context;
        IUserRepository _rep_User;

        public UserEvent(IContext ctx, IUserRepository repUser)
        {
            _context = ctx;
            _rep_User = repUser;
        }

        public void Save(User user)
        {
            User tempInfo = _rep_User.GetItem(Specifications.Specification<User>.Eval(k => k.WorkID == user.WorkID));

            if (tempInfo == null)
            {
                _rep_User.Insert(user);
            }
            else
            {
                _rep_User.Update((User)tempInfo.Cover(user));
            }

            _context.Commit();
        }
    }
}
