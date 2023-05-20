﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl
{
    internal class FulltimeFactory : AbonementFactory
    {
        public override IAbonement Create(double price, TimeSpan timeSpan)
        {
            return new FulltimeAbonement();
        }
    }
}
