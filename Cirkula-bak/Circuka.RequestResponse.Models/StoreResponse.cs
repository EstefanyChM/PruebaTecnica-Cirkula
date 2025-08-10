using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuka.RequestResponse.Models
{
	public class StoreResponse
	{
		public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? BannerUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
		public float DistanceInKm { get; set; }
		public bool IsOpen { get; set; }
	}
}
