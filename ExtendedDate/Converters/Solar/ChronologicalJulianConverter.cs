
namespace Mntone.ExtendedDate.Converters.Solar
{
	public sealed class ChronologicalJulianConverter: JulianConverter
	{
		public static IDateConverter Instance
		{
			get { return _Instance ?? ( _Instance = new ChronologicalJulianConverter() ); }
		}
		private static IDateConverter _Instance;


		private static readonly short[] DaysToMonth365 = { 0, 31, 60, 91, 121, 152, 182, 213, 243, 274, 304, 335, 365 };
		private static readonly short[] DaysToMonth366 = { 0, 31, 61, 92, 122, 153, 183, 214, 244, 275, 305, 336, 366 };

		private ChronologicalJulianConverter()
		{ }

		internal override short[] GetCalendar( bool isLeapYear )
		{
			return isLeapYear ? DaysToMonth366 : DaysToMonth365;
		}
	}
}