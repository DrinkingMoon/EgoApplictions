﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain
{
    /// <summary>
    /// 表示聚合根类型的基类型。
    /// </summary>
    public abstract class AggregateRoot : IAggregateRoot
    {
        protected Guid id;

        /// <summary>
        /// 确定指定的Object是否等于当前的Object。
        /// </summary>
        /// <param name="obj">要与当前对象进行比较的对象。</param>
        /// <returns>如果指定的Object与当前Object相等，则返回true，否则返回false。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.equals。
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!(obj is IAggregateRoot ar))
                return false;
            return this.id == ar.ID;
        }

        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns>当前Object的哈希代码。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.gethashcode。
        /// </remarks>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        //public DateTime? S_CreateTime { get; set; }
        //public string S_CreateUser { get; set; }
        //public DateTime? S_UpdateTime { get; set; }
        //public string S_UpdateUser { get; set; }
        //public DateTime? S_DeleteTime { get; set; }
        //public string S_DeleteUser { get; set; }
    }
}
