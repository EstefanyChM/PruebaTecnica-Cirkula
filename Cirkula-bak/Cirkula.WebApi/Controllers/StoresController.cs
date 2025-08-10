using Circuka.RequestResponse.Models;
using Cirkula.Business;
using Cirkula.DTO.Models;
using DBCirkula.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cirkula.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StoresController : ControllerBase
	{
		
		private readonly StoreBusiness _storeBusiness;

		public StoresController( StoreBusiness storeBusiness )
		{
			_storeBusiness = storeBusiness;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<StoreResponse>>> GetAllAsync()
		{
			IEnumerable<StoreResponse> response = await _storeBusiness.GetAllAsync();
			return Ok(response);
		}

		[HttpGet]
		[Route("GetAllWithDetails")]
		public async Task<ActionResult<IEnumerable<StoreResponse>>> GetAllWithDetails([FromQuery]double latitude, double longitude)
		{
			IEnumerable<StoreResponse> response = await _storeBusiness.GetAllWithDetails(latitude, longitude);
			return Ok(new StoresWrapperResponse { Stores = response });
		}

		[HttpGet]
		[Route("GetById/{id:int}", Name = "GetStore")]
		public async Task<ActionResult<StoreResponse>> GetByIdAsync(int id)
		{
			StoreResponse response = await _storeBusiness.GetByIdAsync(id);
			return Ok(response);
		}

		[HttpPost]
		public async Task<ActionResult<StoreResponse>> CreateAsync(
		    [FromForm] CreateStoreDto createStoreDto,
		    [FromServices] IValidator<CreateStoreDto> validator)
		{
		    var result = await validator.ValidateAsync(createStoreDto);
		
		    if (!result.IsValid)
		        return BadRequest(result.Errors);
		
		    StoreResponse response = await _storeBusiness.CreateAsync(createStoreDto);
		    return CreatedAtRoute("GetStore", new { id = response.Id }, response);
		}


		[HttpPut]
		[Route("{id:int}")]       
		public async Task<ActionResult> UpdateAsync (StoreRequest request)
		{
			await _storeBusiness.UpdateAsync(request);
			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}")]
		public async Task<ActionResult> DeleteAsync(int id)
		{
			await _storeBusiness.DeleteAsync(id);
			return NoContent();
		}	
	}
}
