namespace NhibernateNorthwindDemo.Mappings
{
	using Domain;
	using NHibernate;
	using NHibernate.Mapping.ByCode;
	using NHibernate.Mapping.ByCode.Conformist;

	class CategoryMapping : ClassMapping<Category>
	{
		public CategoryMapping()
		{
			Table("Category");
			Id(c => c.Id, m =>
			{
				m.Column("Id");
				m.Access(Accessor.Property);
				m.Generator(Generators.Assigned);
			});
			Property(c => c.Name, m =>
			{
				m.Column("CategoryName");
				m.Type(NHibernateUtil.AnsiString);
				m.Access(Accessor.Property);
			});
			Property(c => c.Description, m =>
			{
				m.Column("Description");
				m.Type(NHibernateUtil.AnsiString);
				m.Access(Accessor.Property);
			});
			Bag(c => c.Products, bag =>
			{
				bag.Key(k =>
				{
					k.Column("CategoryId");
					k.NotNullable(false);
				});
				//bag.Inverse(false);
				bag.Access(Accessor.Property);
			}, a => a.OneToMany(mapper => mapper.Class(typeof(Product))));
		}
	}
}