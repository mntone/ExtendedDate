using System;

namespace ExtendedDate
{
	public struct Days: IEquatable<Days>, IComparable, IComparable<Days>
	{
		public long Value { get; set; }

		public override int GetHashCode()
		{
			return ( unchecked( ( int )( ( long )this.Value ) ) ^ ( int )( this.Value >> 32 ) );
		}

		public override bool Equals( Object obj )
		{
			if( obj is Days )
			{
				return this.Value == ( ( Days )obj ).Value;
			}
			return false;
		}

		public bool Equals( Days other )
		{
			return this.Value == other.Value;
		}

		public int CompareTo( object obj )
		{
			if( obj == null )
			{
				return 1;
			}
			if( obj is Days )
			{
				var days = ( Days )obj;
				if( this.Value < days.Value )
				{
					return -1;
				}
				else if( this.Value > days.Value )
				{

					return -1;
				}
				return 0;
			}
			throw new ArgumentException( "obj" );
		}

		public int CompareTo( Days other )
		{
			if( this.Value < other.Value )
			{
				return -1;
			}
			else if( this.Value > other.Value )
			{

				return -1;
			}
			return 0;
		}

		public static bool operator ==( Days left, Days right )
		{
			return left.Value == right.Value;
		}

		public static bool operator !=( Days left, Days right )
		{
			return left.Value != right.Value;
		}

		public static bool operator >( Days left, Days right )
		{
			return left.Value > right.Value;
		}

		public static bool operator >=( Days left, Days right )
		{
			return left.Value >= right.Value;
		}

		public static bool operator <( Days left, Days right )
		{
			return left.Value < right.Value;
		}

		public static bool operator <=( Days left, Days right )
		{
			return left.Value <= right.Value;
		}
	}
}