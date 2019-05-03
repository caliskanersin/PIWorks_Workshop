namespace NhibernateNorthwindDemo
{
	using System;
	using System.Collections.Generic;
	using Mappings;
	using NHibernate;
	using NHibernate.Cfg;
	using NHibernate.Cfg.MappingSchema;
	using NHibernate.Mapping.ByCode;

	public static class SessionFactory
	{
		public static ISessionFactory Current { get; private set; }

		public static void CreateSessionFactory()
		{
			try
			{
				var conf = new Configuration();
				var mapper = new ModelMapper();
				mapper.AddMappings(new List<Type>()
				{
					typeof(CategoryMapping),
					typeof(ProductMapping),
					typeof(SupplierMapping),
				});
				HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
				conf.AddMapping(mapping);
				Current = conf.BuildSessionFactory();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}