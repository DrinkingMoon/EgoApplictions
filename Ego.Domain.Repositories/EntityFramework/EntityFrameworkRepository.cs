using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class EntityFrameworkRepository<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IEntityFrameworkRepositoryContext efContext;

        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IEntityFrameworkRepositoryContext)
                this.efContext = context as IEntityFrameworkRepositoryContext;
        }

        protected IEntityFrameworkRepositoryContext EFContext
        {
            get { return this.efContext; }
        }

        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            aggregateRoot.S_CreateTime = DateTime.Now;
            efContext.RegisterNew<TAggregateRoot>(aggregateRoot);
        }

        protected override void DoRemove(TAggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
            {
                return;
            }

            efContext.RegisterDeleted<TAggregateRoot>(aggregateRoot);
        }

        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
            {
                return;
            }

            aggregateRoot.S_UpdateTime = DateTime.Now;
            efContext.RegisterModified<TAggregateRoot>(aggregateRoot);
        }

        protected override void DoSave(TAggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
            {
                return;
            }

            TAggregateRoot tempAggregateRoot = DoGetItem(aggregateRoot.ID);

            if (tempAggregateRoot == null)
            {
                DoAdd(aggregateRoot);
            }
            else
            {
                DoUpdate(aggregateRoot);
            }
        }

        protected override bool DoExists(Guid key)
        {
            var count = efContext.Context.Set<TAggregateRoot>().Where(k => k.ID == key).Count();
            return count != 0;
        }

        protected override bool DoExists(TAggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
            {
                return false;
            }

            var count = efContext.Context.Set<TAggregateRoot>().Where(k => k.ID == aggregateRoot.ID).Count();
            return count != 0;
        }

        protected override TAggregateRoot DoGetItem(Guid key)
        {
            return efContext.Context.Set<TAggregateRoot>().Where(k => k.ID == key).FirstOrDefault();
        }

        protected override TAggregateRoot DoGetItem(Expression<Func<TAggregateRoot, bool>> expression = null)
        {
            if (expression == null)
            {
                return efContext.Context.Set<TAggregateRoot>().FirstOrDefault();
            }
            else
            {
                return efContext.Context.Set<TAggregateRoot>().Where(expression).FirstOrDefault();
            }
        }

        protected override ICollection<TAggregateRoot> DoGetList(Expression<Func<TAggregateRoot, bool>> expression = null)
        {
            if (expression == null)
            {
                return efContext.Context.Set<TAggregateRoot>().ToList();
            }
            else
            {
                return efContext.Context.Set<TAggregateRoot>().Where(expression).ToList();
            }
        }
    }
}
