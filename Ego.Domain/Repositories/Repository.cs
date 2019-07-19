using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories
{
    /// <summary>
    /// Represents the base class for repositories.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root on which the repository operations
    /// should be performed.</typeparam>
    public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        IRepositoryContext context;
        public IRepositoryContext Context { get => context; set => context = value; }



        public Repository(IRepositoryContext context)
        {
            this.context = context;
        }
        protected abstract void DoAdd(TAggregateRoot aggregateRoot);
        protected abstract void DoRemove(TAggregateRoot aggregateRoot);
        protected abstract void DoUpdate(TAggregateRoot aggregateRoot);
        protected abstract void DoSave(TAggregateRoot aggregateRoot);
        protected abstract bool DoExists(Guid key);
        protected abstract bool DoExists(TAggregateRoot aggregateRoot);
        protected abstract TAggregateRoot DoGetItem(Guid key);
        protected abstract TAggregateRoot DoGetItem(Expression<Func<TAggregateRoot, bool>> expression = null);
        protected abstract ICollection<TAggregateRoot> DoGetList(Expression<Func<TAggregateRoot, bool>> expression = null);



        public void Add(TAggregateRoot aggregateRoot)
        {
            DoAdd(aggregateRoot);
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            DoRemove(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            DoUpdate(aggregateRoot);
        }

        public void Save(TAggregateRoot aggregateRoot)
        {
            DoSave(aggregateRoot);
        }

        public bool Exists(Guid key)
        {
           return DoExists(key);
        }

        public bool Exists(TAggregateRoot aggregateRoot)
        {
            return DoExists(aggregateRoot);
        }

        public TAggregateRoot GetItem(Guid key)
        {
            return DoGetItem(key);
        }

        public TAggregateRoot GetItem(Expression<Func<TAggregateRoot, bool>> expression = null)
        {
            return DoGetItem(expression);
        }

        public ICollection<TAggregateRoot> GetList(Expression<Func<TAggregateRoot, bool>> expression = null)
        {
            return DoGetList(expression);
        }
    }
}
