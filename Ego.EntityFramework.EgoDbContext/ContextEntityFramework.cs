
using Ego.Domain.Repositories.EntityFramework;
using Ego.Infrastructure;
using System.Data.Entity;
using System.Threading;

namespace Ego.Domain.Repositories.EFDbContextEgo
{
    public class ContextEntityFramework : Context, IContextEntityFramework
    {
        readonly ThreadLocal<InstanceDbContext> localCtx = new ThreadLocal<InstanceDbContext>();

        public ContextEntityFramework()
        {
            localCtx = new ThreadLocal<InstanceDbContext>(() => { return new InstanceDbContext(); });
        }

        public override void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Add(obj);
            Committed = false;
        }

        public override void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Set<TAggregateRoot>().Attach(obj);
            localCtx.Value.Set<TAggregateRoot>().Remove(obj);
            Committed = false;
        }

        public override void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Modified;
            Committed = false;
        }

        public override bool DistributedTransactionSupported
        {
            get { return true; }
        }

        public override void Rollback()
        {
            Committed = false;
        }

        protected override void DoCommit()
        {
            if (!Committed)
            {
                //var validationErrors = localCtx.Value.GetValidationErrors();
                //var count = localCtx.Value.SaveChanges();
                localCtx.Value.GetValidationErrors();
                localCtx.Value.SaveChanges();

                Committed = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!Committed)
                    Commit();
                localCtx.Value.Dispose();
                localCtx.Dispose();
                base.Dispose(disposing);
            }
        }

        #region IEntityFrameworkRepositoryContext Members

        public DbContext Context
        {
            get { return localCtx.Value; }
        }

        #endregion
    }
}
