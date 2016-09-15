using InTravels.BLL.Interfaces;
using InTravels.BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace InTravels.Util
{
	public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
	{
		private readonly IKernel kernel;
		public NinjectDependencyResolver(IKernel kernel)
		  : base(kernel)
		{
			this.kernel = kernel;
			AddBindings();
		}

		private void AddBindings()
		{
			kernel.Bind<IPostService>().To<PostService>();
			kernel.Bind<IUserService>().To<UserService>();
		}

		public IDependencyScope BeginScope()
		{
			return new NinjectDependencyScope(this.kernel.BeginBlock());
		}
	}
}