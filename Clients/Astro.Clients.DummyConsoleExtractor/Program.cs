using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
			ILogger logger = loggerFactory.GetCurrentClassLogger();

			try
			{

				logger.Info("Getting retriever");

				IRetriever retriever = InstanceContext.Instance.Kernel.Get<IRetriever>();
				logger.Info("Getting results");
				HoroscopeSet retrieveHoroscope = retriever.RetrieveHoroscope(DateTime.Today).Result;
				logger.Info(retrieveHoroscope.ToString());
			}
			catch (Exception ex)
			{
				logger.Fatal(ex,"Got an uncaught exception");
			}
			Console.ReadLine();
		}

		private static void Init()
		{
			InstanceContext.Instance.Initialize(new TwentyMinModule());
		}
	}
}
