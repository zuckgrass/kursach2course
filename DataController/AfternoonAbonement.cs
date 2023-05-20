using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl
{
    internal class AfternoonAbonement : IAbonement
    {
        public double Price()
        {
            return 12999.99;
        }

        public TimeSpan timeSpan()
        {
            TimeSpan startTime = new TimeSpan(13, 0, 0);   // 1 PM
            TimeSpan endTime = new TimeSpan(22, 0, 0);     // 10 PM

            TimeSpan timeRange = endTime - startTime;
            return timeRange;
        }

    }
    
}
