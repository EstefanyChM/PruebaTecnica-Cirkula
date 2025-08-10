using Circuka.RequestResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.DTO.Models
{
	public class StoresWrapperResponse
	{
	    public IEnumerable<StoreResponse> Stores { get; set; }
	}

}
