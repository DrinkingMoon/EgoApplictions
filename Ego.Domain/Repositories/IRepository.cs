using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Repositories
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        #region Properties
        /// <summary>
        /// 获取当前仓储所使用的仓储上下文实例。
        /// </summary>
        IRepositoryContext Context { get; }
        #endregion

        #region Methods
        /// <summary>
        /// 将指定的聚合根添加到仓储中。
        /// </summary>
        /// <param name="aggregateRoot">需要添加到仓储的聚合根实例。</param>
        void Add(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 根据聚合根的ID值，从仓储中读取聚合根。
        /// </summary>
        /// <param name="key">聚合根的ID值。</param>
        /// <returns>聚合根实例。</returns>
        TAggregateRoot GetByKey(Guid key);
        /// <summary>
        /// 返回一个<see cref="Boolean"/>值，该值表示符合指定规约条件的聚合根是否存在。
        /// </summary>
        /// <param name="specification">规约。</param>
        /// <returns>如果符合指定规约条件的聚合根存在，则返回true，否则返回false。</returns>
        bool Exists(ISpecification<TAggregateRoot> specification);
        /// <summary>
        /// 将指定的聚合根从仓储中移除。
        /// </summary>
        /// <param name="aggregateRoot">需要从仓储中移除的聚合根。</param>
        void Remove(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 更新指定的聚合根。
        /// </summary>
        /// <param name="aggregateRoot">需要更新的聚合根。</param>
        void Update(TAggregateRoot aggregateRoot);
        #endregion
    }
}
