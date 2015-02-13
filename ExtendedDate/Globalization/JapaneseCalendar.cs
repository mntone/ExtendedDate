using Mntone.ExtendedDate.Converters.Solar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mntone.ExtendedDate.Globalization
{
	public sealed class JapaneseCalendar: ICalendar<JapaneseEra>
	{
		private static Dictionary<JapaneseEra, Tuple<string, long, long, IDateConverter>> _table = null;

		static JapaneseCalendar()
		{
			_table = new Dictionary<JapaneseEra, Tuple<string, long, long, IDateConverter>>();
			_table[JapaneseEra.Bunroku] = Tuple.Create<string, long, long, IDateConverter>( "文禄", -2915, -1478, GregorianConverter.Instance );
			_table[JapaneseEra.Keicho] = Tuple.Create<string, long, long, IDateConverter>( "慶長", -1478, 5362, GregorianConverter.Instance );
			_table[JapaneseEra.Genna] = Tuple.Create<string, long, long, IDateConverter>( "元和", 5362, 8508, GregorianConverter.Instance );
			_table[JapaneseEra.Kanei] = Tuple.Create<string, long, long, IDateConverter>( "寛永", 8508, 16083, GregorianConverter.Instance );
			_table[JapaneseEra.Shoho] = Tuple.Create<string, long, long, IDateConverter>( "正保", 16083, 17264, GregorianConverter.Instance );
			_table[JapaneseEra.Keian] = Tuple.Create<string, long, long, IDateConverter>( "慶安", 17264, 18921, GregorianConverter.Instance );
			_table[JapaneseEra.Joo] = Tuple.Create<string, long, long, IDateConverter>( "承応", 18921, 19862, GregorianConverter.Instance );
			_table[JapaneseEra.Meireki] = Tuple.Create<string, long, long, IDateConverter>( "明暦", 19862, 21053, GregorianConverter.Instance );
			_table[JapaneseEra.Manji] = Tuple.Create<string, long, long, IDateConverter>( "万治", 21053, 22059, GregorianConverter.Instance );
			_table[JapaneseEra.Kanbun] = Tuple.Create<string, long, long, IDateConverter>( "寛文", 22059, 26602, GregorianConverter.Instance );
			_table[JapaneseEra.Enpo] = Tuple.Create<string, long, long, IDateConverter>( "延宝", 26602, 29534, GregorianConverter.Instance );
			_table[JapaneseEra.Tenna] = Tuple.Create<string, long, long, IDateConverter>( "天和", 29534, 30411, GregorianConverter.Instance );
			_table[JapaneseEra.Jokyo] = Tuple.Create<string, long, long, IDateConverter>( "貞享", 30411, 32073, GregorianConverter.Instance );
			_table[JapaneseEra.Genroku] = Tuple.Create<string, long, long, IDateConverter>( "元禄", 32073, 37726, GregorianConverter.Instance );
			_table[JapaneseEra.Hoei] = Tuple.Create<string, long, long, IDateConverter>( "宝永", 37726, 40339, GregorianConverter.Instance );
			_table[JapaneseEra.Shotoku] = Tuple.Create<string, long, long, IDateConverter>( "正徳", 40339, 42224, GregorianConverter.Instance );
			_table[JapaneseEra.Kyoho] = Tuple.Create<string, long, long, IDateConverter>( "享保", 42224, 49466, GregorianConverter.Instance );
			_table[JapaneseEra.Genbun] = Tuple.Create<string, long, long, IDateConverter>( "元文", 49466, 51237, GregorianConverter.Instance );
			_table[JapaneseEra.Kanpo] = Tuple.Create<string, long, long, IDateConverter>( "寛保", 51237, 52323, GregorianConverter.Instance );
			_table[JapaneseEra.Enkyo] = Tuple.Create<string, long, long, IDateConverter>( "延享", 52323, 53908, GregorianConverter.Instance );
			_table[JapaneseEra.Kanen] = Tuple.Create<string, long, long, IDateConverter>( "寛延", 53908, 55135, GregorianConverter.Instance );
			_table[JapaneseEra.Horeki] = Tuple.Create<string, long, long, IDateConverter>( "宝暦", 55135, 59716, GregorianConverter.Instance );
			_table[JapaneseEra.Meiwa] = Tuple.Create<string, long, long, IDateConverter>( "明和", 59716, 62801, GregorianConverter.Instance );
			_table[JapaneseEra.Anei] = Tuple.Create<string, long, long, IDateConverter>( "安永", 62801, 65860, GregorianConverter.Instance );
			_table[JapaneseEra.Tenmei] = Tuple.Create<string, long, long, IDateConverter>( "天明", 65860, 68714, GregorianConverter.Instance );
			_table[JapaneseEra.Kansei] = Tuple.Create<string, long, long, IDateConverter>( "寛政", 68714, 73127, GregorianConverter.Instance );
			_table[JapaneseEra.Kyowa] = Tuple.Create<string, long, long, IDateConverter>( "享和", 73127, 74225, GregorianConverter.Instance );
			_table[JapaneseEra.Bunka] = Tuple.Create<string, long, long, IDateConverter>( "文化", 74225, 79404, GregorianConverter.Instance );
			_table[JapaneseEra.Bunsei] = Tuple.Create<string, long, long, IDateConverter>( "文政", 79404, 84027, GregorianConverter.Instance );
			_table[JapaneseEra.Tenpo] = Tuple.Create<string, long, long, IDateConverter>( "天保", 84027, 89127, GregorianConverter.Instance );
			_table[JapaneseEra.Koka] = Tuple.Create<string, long, long, IDateConverter>( "弘化", 89127, 90306, GregorianConverter.Instance );
			_table[JapaneseEra.Kaei] = Tuple.Create<string, long, long, IDateConverter>( "嘉永", 90306, 92785, GregorianConverter.Instance );
			_table[JapaneseEra.Ansei] = Tuple.Create<string, long, long, IDateConverter>( "安政", 92785, 94696, GregorianConverter.Instance );
			_table[JapaneseEra.Manen] = Tuple.Create<string, long, long, IDateConverter>( "万延", 94696, 95052, GregorianConverter.Instance );
			_table[JapaneseEra.Bunkyu] = Tuple.Create<string, long, long, IDateConverter>( "文久", 95052, 96145, GregorianConverter.Instance );
			_table[JapaneseEra.Genji] = Tuple.Create<string, long, long, IDateConverter>( "元治", 96145, 96546, GregorianConverter.Instance );
			_table[JapaneseEra.Keio] = Tuple.Create<string, long, long, IDateConverter>( "慶応", 96546, 97816, GregorianConverter.Instance );
			_table[JapaneseEra.Meiji] = Tuple.Create<string, long, long, IDateConverter>( "明治", 97816, 113801, GregorianConverter.Instance );
			_table[JapaneseEra.Taisho] = Tuple.Create<string, long, long, IDateConverter>( "大正", 113801, 119063, GregorianConverter.Instance );
			_table[JapaneseEra.Showa] = Tuple.Create<string, long, long, IDateConverter>( "昭和", 119063, 141720, GregorianConverter.Instance );
			_table[JapaneseEra.Heisei] = Tuple.Create<string, long, long, IDateConverter>( "平成", 141721, long.MaxValue, GregorianConverter.Instance );
		}

		public JapaneseCalendar()
		{
			this.Value = new Days();
			this.IsEnabled = false;
		}

		public JapaneseCalendar( Days days )
		{
			this.Value = days;
			this.IsEnabled = false;
		}

		private Days Value { get; set; }

		private bool IsEnabled { get; set; }
		private JapaneseEra Era { get; set; }
		private Date Cache { get; set; }

		private void Reset()
		{
			this.IsEnabled = false;
		}

		private void Init()
		{
			if( !this.IsEnabled )
			{
				var target = _table.Where( t => t.Value.Item2 <= this.Value.Value && t.Value.Item3 > this.Value.Value ).Single();
				this.Era = target.Key;
				this.Cache = target.Value.Item4.ToDate( this.Value );
			}
		}

		public JapaneseEra GetEra()
		{
			this.Init();
			return this.Era;
		}

		public short GetYear()
		{
			this.Init();
			return this.Cache.Year;
		}

		public char GetMonth()
		{
			this.Init();
			return this.Cache.Month;
		}

		public char GetWeek()
		{
			throw new NotImplementedException();
		}

		public char GetDay()
		{
			this.Init();
			return this.Cache.Day;
		}

		public short GetDayOfYear()
		{
			this.Init();
			return this.Cache.DayOfYear;
		}

		public char GetDayOfWeek()
		{
			this.Init();
			return this.Cache.DayOfWeak;
		}
	}
}