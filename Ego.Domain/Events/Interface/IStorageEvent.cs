﻿using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.Domain.Events.Interface
{
    public interface IStorageEvent
    {
        void Save(Storage storage);
    }
}