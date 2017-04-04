using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astro.Common.Common;
using Astro.Common.Model;
using Astro.Retrievers.Common;
using Astro.Retrievers.TwentyMinRetriever;
using Ninject;
using Ninject.Extensions.Logging;

namespace Astro.Clients.DummyConsoleExtractor
{
	class Program
	{
		static void Main(string[] args)
		{
			Init();
			ILoggerFactory loggerFactory = InstanceContext.Instance.Kernel.Get<ILoggerFactory>();
			ILogger currentClassLogger = loggerFactory.GetCurrentClassLogger();


			currentClassLogger.Info("Getting retriever");

			IRetriever retriever = InstanceContext.Instance.Kernel.Get<IRetriever>();
			currentClassLogger.Info("Getting results");
			HoroscopeSet retrieveHoroscope = retriever.RetrieveHoroscope(DateTime.Today).Result;
			currentClassLogger.Info(retrieveHoroscope.ToString());
			Console.ReadLine();
		}

		private static void Init()
		{
			InstanceContext.Instance.Initialize(new TwentyMinModule());
		}
	}
}
