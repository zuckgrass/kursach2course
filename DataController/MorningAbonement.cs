using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl
{
    class MorningAbonement : IAbonement
    {
        public double Price()
        {
            return 8999.99;
        }

        public TimeSpan timeSpan()
        {
            TimeSpan startTime = new TimeSpan(8, 0, 0);   // 8 AM
            TimeSpan endTime = new TimeSpan(12, 0, 0);     // 12 PM

            TimeSpan timeRange = endTime - startTime;
            return timeRange;
        }
    }
}
