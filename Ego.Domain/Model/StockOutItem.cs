using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class StockOutItem : IEntity
    {
        Guid _id;

        string _billNo;

        Product _product;

        Storage _storage;

        decimal _operationCount;

        string _batchNo;

        StockInBill _stockInBill;

        public StockOutItem()
        {

        }

        public string BillNo { get => _billNo; set => _billNo = value; }
        public virtual Product Product { get => _product; set => _product = value; }
        public virtual Storage Storage { get => _storage; set => _storage = value; }
        public decimal OperationCount { get => _operationCount; set => _operationCount = value; }
        public string BatchNo { get => _batchNo; set => _batchNo = value; }
        public Guid ID { get => _id; set => _id = value; }
        public virtual StockInBill StockInBill { get => _stockInBill; set => _stockInBill = value; }

        #region Public Methods
        /// <summary>
        /// 确定指定的Object是否等于当前的Object。
        /// </summary>
        /// <param name="obj">要与当前对象进行比较的对象。</param>
        /// <returns>如果指定的Object与当前Object相等，则返回true，否则返回false。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.equals。
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;
            if (!(obj is StockInItem other))
                return false;
            return this.ID == other.ID;
        }

        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns>当前Object的哈希代码。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.gethashcode。
        /// </remarks>
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
        #endregion
    }
}
