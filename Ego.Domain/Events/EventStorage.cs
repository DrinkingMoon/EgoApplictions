using Ego.Domain.Events.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Model;
using Ego.Domain.Repositories;

namespace Ego.Domain.Events
{
    public class EventStorage : IEventStorage
    {
        readonly IContext _context;
        readonly IRepStorage _rep_Storage;

        public EventStorage(IContext ctx, IRepStorage repStorage)
        {
            _context = ctx;
            _rep_Storage = repStorage;
        }

        public void Save(Storage storage)
        {
            Storage tempInfo = 
                //_rep_Storage.GetItem(storage.ID);
                _rep_Storage.GetItem(Specifications.Specification<Storage>.Eval(k => k.Name == storage.Name));

            if (tempInfo != null)
            {
                _rep_Storage.Update(tempInfo);
            }
            else
            {
                _rep_Storage.Insert(storage);
            }

            _context.Commit();
        }
    }
}
