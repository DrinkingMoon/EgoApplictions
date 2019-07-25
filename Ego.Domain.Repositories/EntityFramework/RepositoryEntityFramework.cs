using Ego.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Ego.Domain.Repositories.EntityFramework
{
    public class RepositoryEntityFramework<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IContextEntityFramework efContext;

        protected IContextEntityFramework EFContext
        {
            get { return this.efContext; }
        }

        public RepositoryEntityFramework(IContext context)
            : base(context)
        {
            if (context is IContextEntityFramework)
                this.efContext = context as IContextEntityFramework;
        }

        private MemberExpression GetMemberInfo(LambdaExpression lambda)
        {
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        private string GetEagerLoadingPath(Expression<Func<TAggregateRoot, dynamic>> eagerLoadingProperty)
        {
            MemberExpression memberExpression = this.GetMemberInfo(eagerLoadingProperty);
            var parameterName = eagerLoadingProperty.Parameters.First().Name;
            var memberExpressionStr = memberExpression.ToString();
            var path = memberExpressionStr.Replace(parameterName + ".", "");
            return path;
        }
        private bool RemoveHoldingEntityInContext(TAggregateRoot entity)
        {
            var objContext = ((IObjectContextAdapter)efContext.Context).ObjectContext;
            var objSet = objContext.CreateObjectSet<TAggregateRoot>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            var exists = objContext.TryGetObjectByKey(entityKey, out object foundEntity);

            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
        }

        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            efContext.RegisterNew<TAggregateRoot>(aggregateRoot);
        }

        protected override void DoRemove(TAggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
            {
                return;
            }

            RemoveHoldingEntityInContext(aggregateRoot);
            efContext.RegisterDeleted<TAggregateRoot>(aggregateRoot);
        }

        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
            {
                return;
            }

            RemoveHoldingEntityInContext(aggregateRoot);
            efContext.RegisterModified<TAggregateRoot>(aggregateRoot);
        }

        protected override bool DoExists(Guid key)
        {
            var count = efContext.Context.Set<TAggregateRoot>().Where(k => k.ID == key).Count();
            return count != 0;
        }

        protected override bool DoExists(ISpecification<TAggregateRoot> specification)
        {
            var count = efContext.Context.Set<TAggregateRoot>().Count(specification.IsSatisfiedBy);
            return count != 0;
        }

        protected override TAggregateRoot DoGetItem(Guid key)
        {
            return efContext.Context.Set<TAggregateRoot>().Where(k => k.ID == key).FirstOrDefault();
        }

        protected override TAggregateRoot DoGetItem(ISpecification<TAggregateRoot> specification = null)
        {
            return efContext.Context.Set<TAggregateRoot>().Where(specification.IsSatisfiedBy).FirstOrDefault();
        }

        protected override TAggregateRoot DoGetItem(ISpecification<TAggregateRoot> specification = null, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = efContext.Context.Set<TAggregateRoot>();
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (int i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                return dbquery.Where(specification.GetExpression()).FirstOrDefault();
            }
            else
                return dbset.Where(specification.GetExpression()).FirstOrDefault();
        }

        protected override IEnumerable<TAggregateRoot> DoGetList(ISpecification<TAggregateRoot> specification = null)
        {
            var query = efContext.Context.Set<TAggregateRoot>()
                .Where(specification.GetExpression());

            return query.ToList();
        }

        protected override IEnumerable<TAggregateRoot> DoGetList(ISpecification<TAggregateRoot> specification = null, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = efContext.Context.Set<TAggregateRoot>();
            IQueryable<TAggregateRoot> queryable;
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (int i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(specification.GetExpression());
            }
            else
                queryable = dbset.Where(specification.GetExpression());

            return queryable.ToList();
        }
    }
}
