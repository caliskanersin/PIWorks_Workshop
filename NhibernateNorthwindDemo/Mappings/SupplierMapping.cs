namespace NhibernateNorthwindDemo.Mappings
{
	using Domain;
	using NHibernate;
	using NHibernate.Mapping.ByCode;
	using NHibernate.Mapping.ByCode.Conformist;

	class SupplierMapping : ClassMapping<Supplier>
	{
		public SupplierMapping()
		{
			Table("Supplier");
			Id(c => c.Id, m =>
			{
				m.Column("Id");
				m.Access(Accessor.Property);
				m.Generator(Generators.Assigned);
			});
			Property(c => c.CompanyName, m =>
			{
				m.Column("CompanyName");
				m.Type(NHibernateUtil.AnsiString);
				m.Access(Accessor.Property);
			});
			Property(c => c.ContactName, m =>
			{
				m.Column("ContactName");
				m.Type(NHibernateUtil.AnsiString);
				m.Access(Accessor.Property);
			});
			Property(c => c.ContactTitle, m =>
			{
				m.Column("ContactTitle");
				m.Type(NHibernateUtil.AnsiString);
				m.Access(Accessor.Property);
			});
			Component(
				r => r.Address,
				m =>
				{
					m.Property(i => i.Street,
						pm =>
						{
							pm.Column("Address");
							pm.Type(NHibernateUtil.AnsiString);
						});
					m.Property(i => i.City,
						pm => { pm.Column("City"); });
					m.Property(i => i.Region,
						pm => { pm.Column("Region"); });
					m.Property(i => i.PostalCode,
						pm => { pm.Column("PostalCode"); });
					m.Property(i => i.Country,
						pm => { pm.Column("Country"); });
					m.Property(i => i.Phone,
						pm => { pm.Column("Phone"); });
					m.Property(i => i.Fax,
						pm => { pm.Column("Fax"); });
				});
		}
	}
}
