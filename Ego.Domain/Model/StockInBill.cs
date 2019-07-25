using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class StockInBill : AggregateRoot
    {
        string _billNo;

        DateTime? _affirmDate;

        string _billStatus;

        string _createTime;

        string _createUser;

        ICollection<StockInItem> _stockInItems;

        public string BillNo { get => _billNo; set => _billNo = value; }
        public string CreateTime { get => _createTime; set => _createTime = value; }
        public string CreateUser { get => _createUser; set => _createUser = value; }
        public virtual ICollection<StockInItem> StockInItems { get => _stockInItems; set => _stockInItems = value; }
        public string BillStatus { get => _billStatus; set => _billStatus = value; }
        public DateTime? AffirmDate { get => _affirmDate; set => _affirmDate = value; }

        public void Affirm()
        {
            this.AffirmDate = DateTime.Now;
            this.BillStatus = "单据完成";
        }
    }
}
