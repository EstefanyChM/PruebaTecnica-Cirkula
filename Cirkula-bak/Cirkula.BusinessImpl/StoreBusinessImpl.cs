using AutoMapper;
using Circuka.RequestResponse.Models;
using Cirkula.Business;
using Cirkula.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  DBCirkula.Models;
using Cirkula.DTO.Models;
using Cirkula.Services;

namespace Cirkula.BusinessImpl
{
	public class StoreBusinessImpl:StoreBusiness
	{
		private readonly  string folder = "Stores";

		private readonly StoreRepository _storeRepository;
		private readonly UnitOfWork _unitOfWork;
		private readonly FirebaseService _firebaseService;
		private readonly IMapper _mapper;

		public StoreBusinessImpl(
			StoreRepository storeRepository,
			UnitOfWork unitOfWork,
			FirebaseService firebaseService,
			IMapper mapper
			)
		{
			_storeRepository = storeRepository;
			_unitOfWork = unitOfWork;
			_firebaseService = firebaseService;
			_mapper = mapper;
		}

		public async Task<StoreResponse> CreateAsync(StoreRequest entity)
		{
			throw new NotImplementedException();
		}

		public async Task<StoreResponse> CreateAsync(CreateStoreDto entity)
		{
			Store storeDB = _mapper.Map<Store>(entity);

			storeDB.BannerUrl = await _firebaseService.UploadFileAsync(
					entity.BannerImg.OpenReadStream(),
					entity.BannerImg.FileName,
					folder
					);

			storeDB = await _storeRepository.CreateAsync(storeDB);
			
			await _unitOfWork.SaveAsync();

			return _mapper.Map<StoreResponse>(storeDB);
			
		}

		public async Task DeleteAsync(int id)
		{
			Store storeDB = await _storeRepository.GetByIdAsync(id);
			await _storeRepository.DeleteAsync(storeDB);
			await _unitOfWork.SaveAsync();
		}

		public async Task<IEnumerable<StoreResponse>> GetAllAsync()
		{
			IEnumerable<Store> stores = await _storeRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<StoreResponse>>(stores);
		}

		public async Task<IEnumerable<StoreResponse>> GetAllWithDetails(double latitude, double longitude)
		{
		    IEnumerable<Store> stores = await _storeRepository.GetAllAsync();
		
		    var now = TimeOnly.FromDateTime(DateTime.Now);
		
		    var storeResponses = stores.Select(store =>
		    {
		        var response = _mapper.Map<StoreResponse>(store);
		
		        // Calcular distancia
		        response.DistanceInKm = CalculateDistance(latitude, longitude, (double)store.Latitude,		(double)store.Longitude);
		
		        // Determinar si está abierta
		        response.IsOpen = IsStoreOpen(now, store.OpenTime, store.CloseTime);
		
		        return response;
		    });
		
		    return storeResponses;
		}

		public async Task<StoreResponse> GetByIdAsync(int id)
		{
			Store storeDB = await _storeRepository.GetByIdAsync(id);
			return _mapper.Map<StoreResponse>(storeDB);
		}

		public async Task UpdateAsync(StoreRequest entity)
		{
			Store storeDB = _mapper.Map<Store>(entity);
			await _storeRepository.UpdateAsync(storeDB);
			await _unitOfWork.SaveAsync();
		}


		/// <summary>
		/// Calcula la distancia en km usando la fórmula de Haversine.
		/// </summary>
		private static float CalculateDistance(double lat1, double lon1, double lat2, double lon2)
		{
		    const double R = 6371; // Radio de la Tierra en km
		    double dLat = DegreesToRadians(lat2 - lat1);
		    double dLon = DegreesToRadians(lon2 - lon1);
		
		    double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
		               Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
		               Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
		
		    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
		
		    return (float)(R * c);
		}

		private static double DegreesToRadians(double deg) => deg * (Math.PI / 180);
		
		/// <summary>
		/// Determina si una tienda está abierta según la hora actual y su horario.
		/// </summary>
		private static bool IsStoreOpen(TimeOnly now, TimeOnly openTime, TimeOnly closeTime)
		{
		    if (openTime < closeTime)
		    {
		        return now >= openTime && now <= closeTime;
		    }
		    else
		    {
		        return now >= openTime || now <= closeTime;
		    }
		}

	
	}
}
