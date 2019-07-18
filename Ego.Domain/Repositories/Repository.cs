using System;
using System.Collections.Generic;
using System.Linq;
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
        #region Private Fields
        private readonly IRepositoryContext context;
        public IRepositoryContext Context => context;
        #endregion

        /// <summary>
        /// Initializes a new instance of <c>Repository&lt;TAggregateRoot&gt;</c> class.
        /// </summary>
        /// <param name="context">The repository context being used by the repository.</param>
        public Repository(IRepositoryContext context)
        {
            this.context = context;
        }

        #region IRepository<TAggregateRoot> Members
        public void Add(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot GetByKey(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// Adds an aggregate root to the repository.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root to be added to the repository.</param>
        protected abstract void DoAdd(TAggregateRoot aggregateRoot);
        /// <summary>
        /// Gets the aggregate root instance from repository by a given key.
        /// </summary>
        /// <param name="key">The key of the aggregate root.</param>
        /// <returns>The instance of the aggregate root.</returns>
        protected abstract TAggregateRoot DoGetByKey(Guid key);
        /// <summary>
        /// Checkes whether the aggregate root, which matches the given specification, exists in the repository.
        /// </summary>
        /// <param name="specification">The specification with which the aggregate root should match.</param>
        /// <returns>True if the aggregate root exists, otherwise false.</returns>
        protected abstract bool DoExists(ISpecification<TAggregateRoot> specification);
        /// <summary>
        /// Removes the aggregate root from current repository.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root to be removed.</param>
        protected abstract void DoRemove(TAggregateRoot aggregateRoot);
        /// <summary>
        /// Updates the aggregate root in the current repository.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root to be updated.</param>
        protected abstract void DoUpdate(TAggregateRoot aggregateRoot);

        #endregion
    }
}
