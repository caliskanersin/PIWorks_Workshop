namespace NhibernateNorthwindDemo.Domain
{
	class Supplier
	{
		public virtual int Id { get; set; }
		public virtual string CompanyName { get; set; }
		public virtual string ContactName { get; set; }
		public virtual string ContactTitle { get; set; }
		public virtual Address Address { get; set; }
	}
}