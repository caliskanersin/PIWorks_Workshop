namespace NhibernateNorthwindDemo.Domain
{
	using System.Collections.Generic;

	class Category
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual IList<Product> Products { get; set; }
	}
}