
namespace ExtendedDate.Converters.Solar
{
	public sealed class AstronomicalJulianConverter: JulianConverter
	{
		public static IDateConverter Instance
		{
			get { return _Instance ?? ( _Instance = new AstronomicalJulianConverter() ); }
		}
		private static IDateConverter _Instance;


		private static readonly short[] DaysToMonth365 = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
		private static readonly short[] DaysToMonth366 = { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };

		private AstronomicalJulianConverter()
		{ }

		internal override short[] GetCalendar( bool isLeapYear )
		{
			return isLeapYear ? DaysToMonth366 : DaysToMonth365;
		}
	}
}