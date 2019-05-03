namespace SampleHouseWepApi
{
	using System.Web.Http;
	using Autofac;
	using Autofac.Integration.WebApi;
	using Controllers;
	using Owin;
	using Repositories;
	using Services;

	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration
			{
				DependencyResolver = new AutofacWebApiDependencyResolver(CreateContainer())
			};

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			app.UseAutofacWebApi(config);
			app.UseWebApi(config);
		}

		public static IContainer CreateContainer()
		{
			var container = new ContainerBuilder();
			container
				.RegisterType<HouseRepository>()
				.As<IHouseRepository>()
				.SingleInstance();
			container
				.RegisterType<HouseMapper>()
				.As<IHouseMapper>()
				.InstancePerRequest();
			container.RegisterType<HouseController>()
				.InstancePerRequest();
			return container.Build();
		}
	}
}
