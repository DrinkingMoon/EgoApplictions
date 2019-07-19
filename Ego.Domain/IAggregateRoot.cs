using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain
{
    /// <summary>
    /// 表示继承于该接口的类型是聚合根类型。
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        DateTime? S_CreateTime { get; set; }

        string S_CreateUser { get; set; }

        DateTime? S_UpdateTime { get; set; }

        string S_UpdateUser { get; set; }

        DateTime? S_DeleteTime { get; set; }

        string S_DeleteUser { get; set; }
    }
}
