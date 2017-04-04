using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Astro.Common.Model

 
{
	public class Horoscope
	{
		public AstroSign Sign { get; set; }
		public String GlobalText { get; set; }
		public ObservableCollection<HoroscopeTopic> Topics { get; set; }
		public Horoscope()
		{
			Topics = new ObservableCollection<HoroscopeTopic>();
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine(Sign.Name);
			builder.AppendLine(GlobalText);
			foreach (HoroscopeTopic horoscopeTopic in Topics)
			{
				builder.AppendLine(horoscopeTopic.ToString());
			}
			return builder.ToString();
		}
	}
}
