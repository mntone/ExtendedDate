using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mntone.ExtendedDate.Converters.Solar;

namespace Mntone.ExtendedDate.Test
{
	[TestClass]
	public sealed class RevisedJulianConverterUnitTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		//[TestCase( 1, 1, 1, 1, 1, 3 )] <- error
		//[TestCase( 1582, 10, 15, 1582, 10, 5 )]
		//[TestCase( 1583, 1, 1, 1582, 12, 22 )]
		//[TestCase( 1600, 12, 31, 1600, 12, 21 )]
		//[TestCase( 1601, 1, 1, 1600, 12, 22 )]
		//[TestCase( 1752, 9, 5, 1752, 8, 25 )]
		[TestCase( 1923, 10, 1, 1923, 10, 14 )]
		//[TestCase( 1970, 1, 1, 1969, 12, 19 )]
		//[TestCase( 9999, 12, 31 )]
		public void ToDaysTest()
		{
			TestContext.Run( ( int gy, int gm, int gd, int jy, int jm, int jd ) =>
			{
				long expected = ( new DateTime( gy, gm, gd ) - new DateTime( 1601, 1, 1 ) ).Days;
				RevisedJulianConverter.Instance.ToDays( new Date( ( short )jy, ( char )jm, ( char )jd, ( short )0, ( char )0 ) ).Value.Is( expected );
			} );
		}
	}
}