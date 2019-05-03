namespace NhibernateNorthwindDemo
{
	using System;
	using System.Collections;
	using System.Linq;
	using Domain;
	using NHibernate;
	using NHibernate.Linq;
	using NHibernate.Transform;

	class Program
	{
		static void Main(string[] args)
		{
			SessionFactory.CreateSessionFactory();

			GetAllProducts();

			CrudProduct();

			StatelessSession();

			NativeSql();

			Paging();

			Future();
			Console.ReadLine();
		}

		private static void Future()
		{
			using (var session = SessionFactory.Current.OpenSession())
			{
				var suppliers = session.QueryOver<Supplier>().Future();
				var categories = session.QueryOver<Category>().Future();
				var result = suppliers.ToList();
			}
		}

		private static void Paging()
		{
			int count;
			using (var session = SessionFactory.Current.OpenSession())
			{
				count = session.Query<Product>().Count();
			}
			const int pageSize = 5;

			using (var session = SessionFactory.Current.OpenSession())
			{
				var pages = count % pageSize == 0 ? count / pageSize : count / pageSize + 1;

				for (int currentPageIndex = 0; currentPageIndex < pages; currentPageIndex++)
				{
					Console.WriteLine($"Retrieving page {currentPageIndex + 1}");
					var currentPageOfProducts = session.Query<Product>()
						.Skip(currentPageIndex * pageSize)
						.Take(pageSize)
						.ToList();
				}
			}
		}

		private static void NativeSql()
		{
			using (var session = SessionFactory.Current.OpenStatelessSession())
			{
				var trx = session.BeginTransaction();
				session.CreateSQLQuery("Delete from Product where Id=:p")
					.SetInt32("p", 9999)
					.ExecuteUpdate();
				trx.Commit();
			}

			using (var session = SessionFactory.Current.OpenSession())
			{
				var products = session.Query<Product>().ToList();
				var productsSql = (long)session.CreateSQLQuery("select count(*) from product ").UniqueResult();
				Console.WriteLine(products.Count == productsSql);
			}

			using (var session = SessionFactory.Current.OpenSession())
			{
				var productsHashTable = session.CreateSQLQuery("select * from product ")
					.SetResultTransformer(Transformers.AliasToEntityMap).List<Hashtable>();

				var productanonymous = session.Query<Product>().Select(s => new { s.Id, s.Category }).ToList();
			}
		}

		private static void StatelessSession()
		{
			using (var session = SessionFactory.Current.OpenStatelessSession())
			{
				var trx = session.BeginTransaction();
				var category = session.Query<Category>().FirstOrDefault(s => s.Id == 1);
				var supplier = session.Query<Supplier>().FirstOrDefault(s => s.Id == 1);
				var newProduct = new Product
				{
					Category = category,
					Supplier = supplier,
					Id = 9999,
					Name = "Test",
					QuantityPerUnit = "Test unit"
				};
				session.Insert(newProduct);
				trx.Commit();
			}
		}

		private static void CrudProduct()
		{
			using (var session = SessionFactory.Current.OpenSession())
			{
				var trx = session.BeginTransaction();
				var category = session.Query<Category>().FirstOrDefault(s => s.Id == 1);
				var supplier = session.Query<Supplier>().FirstOrDefault(s => s.Id == 1);
				var newProduct = new Product
				{
					Category = category,
					Supplier = supplier,
					Id = 9999,
					Name = "Test",
					QuantityPerUnit = "Test unit"
				};
				session.Save(newProduct);
				trx.Commit();
			}
			using (var session = SessionFactory.Current.OpenSession())
			{
				var trx = session.BeginTransaction();
				var product = session.Query<Product>().FirstOrDefault(p => p.Id == 9999);
				product.QuantityPerUnit = "updated";
				session.Update(product);
				trx.Commit();
			}
			using (var session = SessionFactory.Current.OpenSession())
			{
				var trx = session.BeginTransaction();
				var product = session.Query<Product>().FirstOrDefault(p => p.Id == 9999);
				session.Delete(product);
				trx.Commit();
			}
		}

		private static void GetAllProducts()
		{
			using (var session = SessionFactory.Current.OpenSession())
			{
				var trx = session.BeginTransaction();
				var products = session.Query<Product>().ToList();
				trx.Commit();
			}
		}
	}
}
