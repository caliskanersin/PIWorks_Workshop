namespace SampleHouseWepApi.Controllers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Web.Http;
	using System.Web.Http.OData;
	using Repositories;
	using SampleHouseDomain.Models;
	using Services;

	[RoutePrefix("api/house")]
	public class HouseController : ApiController
	{
		private readonly IHouseRepository houseRepository;
		private readonly IHouseMapper houseMapper;

		public HouseController(IHouseRepository houseRepository, IHouseMapper houseMapper)
		{
			this.houseRepository = houseRepository;
			this.houseMapper = houseMapper;
		}

		[HttpGet]
		[Route("Get")]
		public IHttpActionResult Get()
		{
			List<HouseEntity> result = houseRepository.GetAll();
			return Ok(result.Select(x => houseMapper.MapToDto(x)));
		}

		[HttpGet]
		[Route("GetSingleHouse/{id}")]
		public IHttpActionResult GetSingle(int id)
		{
			HouseEntity houseEntity = houseRepository.GetSingle(id);

			if (houseEntity == null)
			{
				return NotFound();
			}

			return Ok(houseMapper.MapToDto(houseEntity));
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Create([FromBody] HouseDto houseDto)
		{
			if (houseDto == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			HouseEntity houseEntity = houseMapper.MapToEntity(houseDto);

			houseRepository.Add(houseEntity);

			return Ok(houseEntity);
		}

		[HttpPut]
		[Route("{id}")]
		public IHttpActionResult Update(int id, [FromBody] HouseDto houseDto)
		{
			if (houseDto == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			HouseEntity houseEntityToUpdate = houseRepository.GetSingle(id);

			if (houseEntityToUpdate == null)
			{
				return NotFound();
			}

			houseEntityToUpdate.ZipCode = houseDto.ZipCode;
			houseEntityToUpdate.Street = houseDto.Street;
			houseEntityToUpdate.City = houseDto.City;

			HouseEntity houseEntity = houseRepository.Update(houseEntityToUpdate);

			return Ok(houseMapper.MapToDto(houseEntity));
		}

		[HttpPatch]
		[Route("{id}")]
		public IHttpActionResult Patch(int id, Delta<HouseDto> houseDto)
		{
			if (houseDto == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			HouseEntity houseEntityToUpdate = houseRepository.GetSingle(id);

			if (houseEntityToUpdate == null)
			{
				return NotFound();
			}

			HouseDto existingHouse = houseMapper.MapToDto(houseEntityToUpdate);
			houseDto.Patch(existingHouse);

			HouseEntity patched = houseRepository.Update(houseMapper.MapToEntity(existingHouse));

			return Ok(houseMapper.MapToDto(patched));
		}

		[HttpPost]
		[Route("{id}")]
		public IHttpActionResult Delete(int id)
		{
			HouseEntity houseEntityToDelete = houseRepository.GetSingle(id);

			if (houseEntityToDelete == null)
			{
				return NotFound();
			}

			houseRepository.Delete(id);

			return StatusCode(HttpStatusCode.NoContent);
		}
	}
}