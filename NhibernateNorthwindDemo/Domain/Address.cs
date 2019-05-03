namespace NhibernateNorthwindDemo.Domain
{
	internal class Address
	{
		public virtual string Street { get; set; }
		public virtual string City { get; set; }
		public virtual string Region { get; set; }
		public virtual string PostalCode { get; set; }
		public virtual string Country { get; set; }
		public virtual string Phone { get; set; }
		public virtual string Fax { get; set; }
	}
}