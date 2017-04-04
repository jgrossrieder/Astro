using System;

namespace Astro.Common.Model

 
{
	public class HoroscopeTopic
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int TotalStars { get; set; }
		public int Stars { get; set; }
		public override string ToString()
		{
			return $"{Title}: {Stars}/{TotalStars}{Environment.NewLine}{Description}";
		}
	}
}