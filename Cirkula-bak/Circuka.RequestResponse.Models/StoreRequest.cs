using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuka.RequestResponse.Models
{
	public class StoreRequest
	{
		public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? BannerUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
	}
}
