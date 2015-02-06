using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtendedDate.Converters.Solar;

namespace ExtendedDate.Test
{
	[TestClass]
	public sealed class GregorianConverterUnitTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		[TestCase( 1, 1, 1 )]
		[TestCase( 1582, 10, 15 )]
		[TestCase( 1583, 1, 1 )]
		[TestCase( 1600, 12, 31 )]
		[TestCase( 1601, 1, 1 )]
		[TestCase( 1752, 9, 15 )]
		[TestCase( 1970, 1, 1 )]
		[TestCase( 9999, 12, 31 )]
		public void ToDaysTest()
		{
			TestContext.Run( ( int year, int month, int day ) =>
			{
				long expected = ( new DateTime( year, month, day ) - new DateTime( 1601, 1, 1 ) ).Days;
				GregorianConverter.Instance.ToDays( new Date( ( short )year, ( char )month, ( char )day, ( short )0, ( char )0 ) ).Value.Is( expected );
			} );
		}
	}
}
