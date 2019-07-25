using Ego.Domain;
using Ego.Domain.Repositories;
using Ego.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Events.Interface;
using Ego.Domain.Model;

namespace Ego.Application
{
    public class StorageApp
    {
        readonly IContext _context;
        readonly IRepStorage _rep_Storage;

        readonly IEventStorage _event_Storage;

        public StorageApp()
        {
            _context = ServiceLocator.Instance.GetService<IContext>();

            _rep_Storage = ServiceLocator.Instance.GetService<IRepStorage>
                (new KeyValuePair<string, object>("ctx", _context));

            _event_Storage = new Ego.Domain.Events.EventStorage(_context, _rep_Storage);

            //_event_Storage = ServiceLocator.Instance.GetService<IEventStorage>
            //    (new KeyValuePair<string, object>("ctx", _context),
            //    new KeyValuePair<string, object>("repStorage", _rep_Storage));
        }

        public void Save(Storage storage)
        {
            _event_Storage.Save(storage);
        }
    }
}
