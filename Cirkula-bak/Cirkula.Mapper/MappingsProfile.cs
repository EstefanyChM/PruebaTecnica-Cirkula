using AutoMapper;
using Circuka.RequestResponse.Models;
using Cirkula.DTO.Models;
using DBCirkula.Models;
using System.Globalization;
using UtilConstants;

namespace Cirkula.Mapper
{
	public class MappingsProfile :Profile
	{
		public MappingsProfile ()
		{
			CreateMap<StoreRequest, Store>().ReverseMap();
			//CreateMap<Store, StoreResponse>().ReverseMap();
			CreateMap<Store, CreateStoreDto>().ReverseMap();


			CreateMap<Store, StoreResponse>()
                .ForMember(dest => dest.OpenTime, opt =>
                    opt.MapFrom(src => src.OpenTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.CloseTime, opt =>
                    opt.MapFrom(src => src.CloseTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)));
        }
	}
}
