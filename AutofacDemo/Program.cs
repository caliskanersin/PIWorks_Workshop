namespace AutofacDemo
{
	using System;
	using System.Threading;
	using Autofac;

	class Program
	{
		static void Main(string[] args)
		{
			ContainerBuilder buider=new ContainerBuilder();
			buider.RegisterType<Logger>().As<ILogger>();
			buider.RegisterType<Dependency>().AsSelf();
			var container=buider.Build();
			var logger = container.Resolve<ILogger>();
			logger.Talk();
			var newDependency = new Dependency2();
			using (var scope = container.BeginLifetimeScope(
				builder => { builder.RegisterInstance(newDependency); }))
			{
				var childDependency = scope.Resolve<Dependency2>();
				childDependency.Progress();
			}

			Console.ReadLine();
		}

		interface ILogger
		{
			void Talk();
		}

		class Logger : ILogger
		{
			private readonly Dependency dependency;

			public Logger(Dependency dependency)
			{
				this.dependency = dependency;
			}

			public void Talk()
			{
				Console.WriteLine("Hi I am logger");
				Thread.Sleep(2000);
				dependency.Progress();
			}
		}

		class Dependency
		{
			public void Progress()
			{
				Console.WriteLine($"I am dependency.");
			}
		}

		class Dependency2
		{
			public void Progress()
			{
				Console.WriteLine($"I am dependency2.");
			}
		}
	}
}

