namespace SampleHouseWepApi.Repositories
{
	using System.Collections.Generic;
	using System.Linq;
	using SampleHouseDomain.Models;

	public class HouseRepository : IHouseRepository
	{
		readonly Dictionary<int, HouseEntity> houses = new Dictionary<int, HouseEntity>();

		public HouseRepository()
		{
			houses.Add(1, new HouseEntity() { City = "Istanbul", Id = 1, Street = "Street1", ZipCode = 1234 });
			houses.Add(2, new HouseEntity() { City = "Istanbul", Id = 2, Street = "Street2", ZipCode = 1234 });
			houses.Add(3, new HouseEntity() { City = "Istanbul", Id = 3, Street = "Street3", ZipCode = 1234 });
			houses.Add(4, new HouseEntity() { City = "Istanbul", Id = 4, Street = "Street4", ZipCode = 1234 });
		}

		public List<HouseEntity> GetAll()
		{
			return houses.Select(x => x.Value).ToList();
		}

		public HouseEntity GetSingle(int id)
		{
			return houses.FirstOrDefault(x => x.Key == id).Value;
		}

		public HouseEntity Add(HouseEntity toAdd)
		{
			int newId = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;
			toAdd.Id = newId;
			houses.Add(newId, toAdd);
			return toAdd;
		}

		public HouseEntity Update(HouseEntity toUpdate)
		{
			HouseEntity single = GetSingle(toUpdate.Id);

			if (single == null)
			{
				return null;
			}

			houses[single.Id] = toUpdate;
			return toUpdate;
		}

		public void Delete(int id)
		{
			houses.Remove(id);
		}
	}
}