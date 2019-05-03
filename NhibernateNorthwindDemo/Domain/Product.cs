namespace NhibernateNorthwindDemo.Domain
{
	class Product
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string QuantityPerUnit { get; set; }
		public virtual Category Category { get; set; }
		public virtual Supplier Supplier { get; set; }
		public virtual int UnitPrice { get; set; }
		public virtual int UnitsInStock { get; set; }
		public virtual int UnitsOnOrder { get; set; }
		public virtual int ReorderLevel { get; set; }
		public virtual int Discontinued { get; set; }
	}
}