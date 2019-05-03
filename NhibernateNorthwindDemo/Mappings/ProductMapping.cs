namespace NhibernateNorthwindDemo.Mappings
{
	using Domain;
	using NHibernate;
	using NHibernate.Mapping.ByCode;
	using NHibernate.Mapping.ByCode.Conformist;

	class ProductMapping : ClassMapping<Product>
	{
		public ProductMapping()
		{
			Table("Product");
			Id(c => c.Id, m =>
			 {
				 m.Column("Id");
				 m.Access(Accessor.Property);
				 m.Generator(Generators.Assigned);
			 });
			Property(c => c.Name, m =>
			{
				m.Column("ProductName");
				m.Type(NHibernateUtil.AnsiString);
				m.Access(Accessor.Property);
			});
			Property(c => c.QuantityPerUnit, m =>
			{
				m.Column("QuantityPerUnit");
				m.Type(NHibernateUtil.AnsiString);
				m.Access(Accessor.Property);
			});
			Property(c => c.UnitPrice, m =>
			{
				m.Column("UnitPrice");
				m.Access(Accessor.Property);
			});
			Property(c => c.UnitsInStock, m =>
			{
				m.Column("UnitsInStock");
				m.Access(Accessor.Property);
			});
			Property(c => c.UnitsOnOrder, m =>
			{
				m.Column("UnitsOnOrder");
				m.Access(Accessor.Property);
			});
			Property(c => c.ReorderLevel, m =>
			{
				m.Column("ReorderLevel");
				m.Access(Accessor.Property);
			});
			Property(c => c.Discontinued, m =>
			{
				m.Column("Discontinued");
				m.Access(Accessor.Property);
			});
			ManyToOne(x => x.Category, m =>
			{
				m.Column("CategoryId");
				m.Lazy(LazyRelation.NoLazy);
				m.Fetch(FetchKind.Join);
				m.NotFound(NotFoundMode.Ignore);
			});
			ManyToOne(x => x.Supplier, m =>
			{
				m.Column("SupplierId");
				//m.Lazy(LazyRelation.NoLazy);
				//m.Fetch(FetchKind.Join);
				m.NotFound(NotFoundMode.Ignore);
			});
		}
	}
}
