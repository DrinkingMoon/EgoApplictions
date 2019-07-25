using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class StockOutBill : AggregateRoot
    {
        string _billNo;

        string _createTime;

        string _createUser;

        ICollection<StockInItem> _detailItems;

        public string BillNo { get => _billNo; set => _billNo = value; }
        public string CreateTime { get => _createTime; set => _createTime = value; }
        public string CreateUser { get => _createUser; set => _createUser = value; }
        public virtual ICollection<StockInItem> DetailItems { get => _detailItems; set => _detailItems = value; }
    }
}
