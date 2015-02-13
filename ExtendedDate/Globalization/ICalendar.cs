
namespace Mntone.ExtendedDate
{
	public interface ICalendar<TEra>
	{
		TEra GetEra();
		short GetYear();
		char GetMonth();
		char GetWeek();
		char GetDay();

		short GetDayOfYear();
		char GetDayOfWeek();
	}
}