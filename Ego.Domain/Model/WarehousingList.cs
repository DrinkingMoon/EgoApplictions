﻿using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Model
{
    public class WarehousingList : AggregateRoot
    {
        string _billNo;

        string _createTime;

        string _createUser;

        IEnumerable<DetailItem> _detailItems;

        public string BillNo { get => _billNo; set => _billNo = value; }
        public string CreateTime { get => _createTime; set => _createTime = value; }
        public string CreateUser { get => _createUser; set => _createUser = value; }
        public virtual IEnumerable<DetailItem> DetailItems { get => _detailItems; set => _detailItems = value; }
    }
}