using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl
{
    internal abstract class AbonementFactory
    {
        abstract public IAbonement Create(double price, TimeSpan timeSpan);
    }
}
