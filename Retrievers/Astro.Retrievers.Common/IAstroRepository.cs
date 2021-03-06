﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astro.Common.Model;

namespace Astro.Retrievers.Common
{
	public interface IAstroRepository
	{
		Task<HoroscopeSet> GetHoroscopes(DateTime date);
	}
}
