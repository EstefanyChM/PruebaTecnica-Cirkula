using Circuka.RequestResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.Business
{
	public interface StoreBusiness :CRUDBusiness<StoreRequest, StoreResponse>
	{
		Task<IEnumerable<StoreResponse>> GetAllWithDetails(double latitude, double longitude);
	}
}
