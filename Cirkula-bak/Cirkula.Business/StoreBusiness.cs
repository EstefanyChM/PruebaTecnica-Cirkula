using Circuka.RequestResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirkula.DTO.Models;

namespace Cirkula.Business
{
	public interface StoreBusiness :CRUDBusiness<StoreRequest, StoreResponse>
	{
		Task<IEnumerable<StoreResponse>> GetAllWithDetails(double latitude, double longitude);

		Task<StoreResponse> CreateAsync(CreateStoreDto entity);
	}
}
