﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal interface ICustomList
    {
        public void Add(IItem item);
        
        public void DisplayList();
    }
}
