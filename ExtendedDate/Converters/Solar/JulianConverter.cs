using System;

namespace Mntone.ExtendedDate.Converters.Solar
{
	public abstract class JulianConverter: IDateConverter
	{
		protected const int YearsOffset = -1601;

		protected const int DaysPerYears = 365;
		protected const int DaysPer4Years = 4 * DaysPerYears + 1;

		protected JulianConverter()
		{ }

		public Date ToDate( Days value )
		{
			var d = value.Value;

			var y4 = d / DaysPer4Years;
			d -= y4;

			var y1 = d / DaysPerYears;
			if( y1 == 4 )
			{
				y1 = 3;
			}
			d -= y1 * DaysPerYears;

			var leap = y1 == 3;
			var m = d >> 5 + 1;
			var days = this.GetCalendar( leap );
			while( m >= days[m] )
			{
				++m;
			}

			return new Date(
				( short )( 4 * y4 + y1 + 1 ),
				( char )m,
				( char )( d - days[m - 1] + 1 ),
				( short )( d + 1 ),
				( char )( ( d + 1 ) % 7 ) );
		}

		public Days ToDays( Date value )
		{
			return new Days() { Value = DateToDays( value ) };
		}

		internal bool GetIsLeapYear( long years )
		{
			return years % 4 == 0;
		}

		internal abstract short[] GetCalendar( bool isLeapYear );

		internal int GetLastDay( char month, short[] calendar )
		{
			return calendar[month] - calendar[month - 1];
		}

		internal long DateToDays( Date value )
		{
			var year = value.Year;
			var month = value.Month;
			var day = value.Day;

			if( month < 1 || month > 12 )
			{
				throw new ArgumentOutOfRangeException( "value" );
			}

			var leap = this.GetIsLeapYear( year );
			var calendar = this.GetCalendar( leap );
			if( day < 1 || day > this.GetLastDay( month, calendar ) )
			{
				throw new ArgumentOutOfRangeException( "value" );
			}

			var yearWithOffset = year + YearsOffset;
			if( yearWithOffset < 0 )
			{
				return DaysPerYears * yearWithOffset + ( yearWithOffset - 3 ) / 4 + calendar[month - 1] + day + 8;
			}
			return DaysPerYears * yearWithOffset + yearWithOffset / 4 + calendar[month - 1] + day + 8;
		}
	}
}