using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace Astro.Common.Common
{
	public class InstanceContext
	{
		public static InstanceContext Instance { get; }= new InstanceContext();

		public IKernel Kernel { get; private set; }


		public void Initialize(params INinjectModule [] modules)
		{
			Kernel = new StandardKernel(modules);
		}


	}
}
