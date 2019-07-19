using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ego.Domain.Specifications;

namespace Ego.Domain
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
        protected abstract bool DoExists(Guid key);
        protected abstract bool DoExists(ISpecification<TAggregateRoot> specification);
        protected abstract TAggregateRoot DoGetItem(Guid key);
        protected abstract TAggregateRoot DoGetItem(ISpecification<TAggregateRoot> specification = null);
        protected abstract TAggregateRoot DoGetItem(ISpecification<TAggregateRoot> specification = null, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        protected abstract IEnumerable<TAggregateRoot> DoGetList(ISpecification<TAggregateRoot> specification = null);
        protected abstract IEnumerable<TAggregateRoot> DoGetList(ISpecification<TAggregateRoot> specification = null, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);


        public void Add(TAggregateRoot aggregateRoot)
        {
            this.DoAdd(aggregateRoot);
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            this.DoRemove(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            this.DoUpdate(aggregateRoot);
        }

        public bool Exists(Guid key)
        {
            return DoExists(key);
        }

        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            return DoExists(specification);
        }

        public TAggregateRoot GetItem(Guid key)
        {
            return DoGetItem(key);
        }

        public TAggregateRoot GetItem(ISpecification<TAggregateRoot> specification = null)
        {
            return DoGetItem(specification);
        }

        public TAggregateRoot GetItem(ISpecification<TAggregateRoot> specification = null, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoGetItem(specification, eagerLoadingProperties);
        }

        public IEnumerable<TAggregateRoot> GetList(ISpecification<TAggregateRoot> specification = null)
        {
            return DoGetList(specification);
        }

        public IEnumerable<TAggregateRoot> GetList(ISpecification<TAggregateRoot> specification = null, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoGetList(specification, eagerLoadingProperties);
        }
    }
}
