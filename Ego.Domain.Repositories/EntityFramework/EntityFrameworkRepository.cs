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

        protected IEntityFrameworkRepositoryContext EFContext
        {
            get { return this.efContext; }
        }

        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            efContext.RegisterNew<TAggregateRoot>(aggregateRoot);
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

        protected override void DoRemove(TAggregateRoot aggregateRoot)
        {
            efContext.RegisterDeleted<TAggregateRoot>(aggregateRoot);
        }

        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
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

        protected override TAggregateRoot DoGetItem(Guid key)
        {
            return efContext.Context.Set<TAggregateRoot>().Where(k => k.ID == key).FirstOrDefault();
        }

        protected override TAggregateRoot DoGetItem(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return efContext.Context.Set<TAggregateRoot>().Where(expression).FirstOrDefault();
        }

        protected override ICollection<TAggregateRoot> DoGetList(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return efContext.Context.Set<TAggregateRoot>().Where(expression).ToList();
        }
    }
}
