using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astro.Common.Model;
using Astro.Retrievers.Common;

namespace Astro.Common.Repository
{
	public class AstroRepository: IAstroRepository
	{
		private readonly IRetriever _retriever;
		


		public AstroRepository(IRetriever retriever)
		{
			_retriever = retriever;
		}

		public async Task<HoroscopeSet> GetHoroscopes(DateTime date)
		{
			//TODO Implement Database/Cache
			return await _retriever.RetrieveHoroscope(date);
		}
	}
}
