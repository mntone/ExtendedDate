
namespace ExtendedDate
{
	public interface IDateConverter
	{
		Date ToDate( Days value );
		Days ToDays( Date value );
	}
}