using Astro.Retrievers.Common;
using Ninject.Modules;

namespace Astro.Retrievers.TwentyMinRetriever
{
	public class TwentyMinModule: NinjectModule
	{
		public override void Load()
		{

			Bind<IRetriever>().To<TwentyMinRetriever>();
		}
	}
}
