﻿namespace SampleHouseWepApi.Services
{
	using SampleHouseDomain.Models;

	public class HouseMapper : IHouseMapper
	{
		public HouseDto MapToDto(HouseEntity houseEntity)
		{
			return new HouseDto()
			{
				Id = houseEntity.Id,
				ZipCode = houseEntity.ZipCode,
				City = houseEntity.City,
				Street = houseEntity.Street
			};
		}

		public HouseEntity MapToEntity(HouseDto houseDto)
		{
			return new HouseEntity()
			{
				Id = houseDto.Id,
				ZipCode = houseDto.ZipCode,
				City = houseDto.City,
				Street = houseDto.Street
			};
		}
	}
}