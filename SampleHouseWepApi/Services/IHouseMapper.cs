namespace SampleHouseWepApi.Services
{
	using SampleHouseDomain.Models;

	public interface IHouseMapper
	{
		HouseDto MapToDto(HouseEntity houseEntity);
		HouseEntity MapToEntity(HouseDto houseDto);
	}
}