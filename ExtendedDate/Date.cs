using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedDate
{
	public struct Date
	{
		public Date( short year, char month, char day, short dayOfYear, char dayOfWeek )
			: this()
		{
			this.Year = year;
			this.Month = month;
			this.Day = day;

			this.DayOfYear = dayOfYear;
			this.DayOfWeak = dayOfWeek;
		}

		public short Year { get; private set; }
		public char Month { get; private set; }
		public char Day { get; private set; }

		public short DayOfYear { get; private set; }
		public char DayOfWeak { get; private set; }
	}
}