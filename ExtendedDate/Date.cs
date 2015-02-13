using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mntone.ExtendedDate
{
	public struct Date: IEquatable<Date>
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

		public override int GetHashCode()
		{
			return ( unchecked( ( int )( ( ( int )this.Year ) << 16 | ( ( int )this.Month ) << 8 | ( int )this.Day ) ) );
		}

		public override bool Equals( Object obj )
		{
			if( obj is Date )
			{
				var other = ( Date )obj;
				return this.Year == other.Year && this.Month == other.Month && this.Day == other.Day;
			}
			return false;
		}

		public bool Equals( Date other )
		{
			return this.Year == other.Year && this.Month == other.Month && this.Day == other.Day;
		}

		public static bool operator ==( Date left, Date right )
		{
			return left.Year == right.Year && left.Month == right.Month && left.Day == right.Day;
		}

		public static bool operator !=( Date left, Date right )
		{
			return left.Year != right.Year || left.Month != right.Month || left.Day != right.Day;
		}

		public short Year { get; private set; }
		public char Month { get; private set; }
		public char Day { get; private set; }

		public short DayOfYear { get; private set; }
		public char DayOfWeak { get; private set; }
	}
}