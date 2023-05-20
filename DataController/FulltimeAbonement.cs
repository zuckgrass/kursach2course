using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl
{
    internal class FulltimeAbonement : IAbonement
    {
        public double Price()
        {
            return 15999.99;
        }

        public TimeSpan timeSpan()
        {
            TimeSpan startTime = new TimeSpan(8, 0, 0);   // 8 AM
            TimeSpan endTime = new TimeSpan(22, 0, 0);     // 22 PM

            TimeSpan timeRange = endTime - startTime;
            return timeRange;
        }
    }
}
