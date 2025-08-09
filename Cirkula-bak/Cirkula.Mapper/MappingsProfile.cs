using AutoMapper;
using Circuka.RequestResponse.Models;
using DBCirkula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.Mapper
{
	public class MappingsProfile :Profile
	{
		public MappingsProfile ()
		{
			CreateMap<Store, StoreRequest>().ReverseMap();
			CreateMap<Store, StoreResponse>().ReverseMap();
		}
	}
}
