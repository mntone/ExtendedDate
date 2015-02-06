using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedDate
{
    public struct Days
    {
		// Julian 
		private const int JulianDaysPerYear = 365;
		private const int JulianDaysPer4Years = 4 * JulianDaysPerYear + 1;
		private const int JulianDaysPer100Years = 25 * JulianDaysPer4Years;
		private const int JulianDaysPer400Years = 4 * JulianDaysPer100Years;

		public long Value { get; set; }
    }
}