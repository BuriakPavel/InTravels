using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace InTravels.Util
{
	public class NinjectDependencyScope : IDependencyScope
	{
		private IResolutionRoot resolver;

		internal NinjectDependencyScope(IResolutionRoot _resolver)
		{
			//Contract.Assert(resolver != null);

			resolver = _resolver;
		}

		public void Dispose()
		{
			var disposable = this.resolver as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}

			resolver = null;
		}

		public object GetService(Type serviceType)
		{
			return resolver.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return resolver.GetAll(serviceType);
		}
	}
}