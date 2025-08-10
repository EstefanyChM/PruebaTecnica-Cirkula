using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cirkula.DTO.Models
{
	public class CreateStoreDto
	{
        public string Name { get; set; } = null!;
		public IFormFile? BannerImg { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
	}
}
