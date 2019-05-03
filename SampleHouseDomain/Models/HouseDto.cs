namespace SampleHouseDomain.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class HouseDto
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Street { get; set; }

		[DataMember]
		public string City { get; set; }

		[DataMember]
		public int ZipCode { get; set; }
	}
}