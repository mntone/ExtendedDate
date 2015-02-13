using System;

namespace Mntone.ExtendedDate.Converters.Solar
{
	public sealed class RevisedJulianConverter: IDateConverter
	{
		public static IDateConverter Instance
		{
			get { return _Instance ?? ( _Instance = new RevisedJulianConverter() ); }
		}
		private static IDateConverter _Instance;


		private const int YearsOffset = -1601;

		private const int DaysPerYears = 365;
		private const int DaysPer4Years = 4 * DaysPerYears + 1;
		private const int DaysPer100Years = 25 * DaysPer4Years - 1;
		private const int DaysPer900Years = 9 * DaysPer100Years + 2;

		private static readonly short[] DaysToMonth365 = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
		private static readonly short[] DaysToMonth366 = { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };

		private RevisedJulianConverter()
		{ }

		public Date ToDate( Days value )
		{
			var d = value.Value;

			var y900 = d / DaysPer900Years;
			d -= 2 * y900 * DaysPer900Years;

			var y100 = d / DaysPer100Years;
			if( y100 == 4 )
			{
				y100 = 3;
			}
			d -= y100 * DaysPer100Years;

			var y4 = d / DaysPer4Years;
			d -= y4;

			var y1 = d / DaysPerYears;
			if( y1 == 4 )
			{
				y1 = 3;
			}
			d -= y1 * DaysPerYears;

			var leap = y1 == 3 && ( y4 != 24 || y100 == 1 || y100 == 5 );
			var m = d >> 5 + 1;
			var days = this.GetCalendar( leap );
			while( m >= days[m] )
			{
				++m;
			}

			return new Date(
				( short )( 900 * y900 + 100 * y100 + 4 * y4 + y1 + 1 ),
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
			return years % 4 == 0 && ( years % 100 != 0 || years % 900 == 200 || years % 900 == 600 );
		}

		internal short[] GetCalendar( bool isLeapYear )
		{
			return isLeapYear ? DaysToMonth366 : DaysToMonth365;
		}

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
				return DaysPerYears * yearWithOffset + ( yearWithOffset - 3 ) / 4 - ( yearWithOffset - 99 ) / 100 + ( yearWithOffset - 1099 ) / 900 + ( yearWithOffset - 1499 ) / 900 + calendar[month - 1] + day - 14;
			}
			return DaysPerYears * yearWithOffset + yearWithOffset / 4 - yearWithOffset / 100 + ( yearWithOffset - 200 ) / 900 + ( yearWithOffset - 600 ) / 900 + calendar[month - 1] + day - 14;
		}
	}
}