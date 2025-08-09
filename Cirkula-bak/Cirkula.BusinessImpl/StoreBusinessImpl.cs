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

namespace Cirkula.BusinessImpl
{
	public class StoreBusinessImpl:StoreBusiness
	{
		private readonly StoreRepository _storeRepository;
		private readonly UnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public StoreBusinessImpl(
			StoreRepository storeRepository,
			UnitOfWork unitOfWork,
			IMapper mapper
			)
		{
			_storeRepository = storeRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<StoreResponse> CreateAsync(StoreRequest entity)
		{
			Store storeDB = _mapper.Map<Store>(entity);
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
			IEnumerable <Store> stores = await _storeRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<StoreResponse>>(stores);
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

		public Task UpdateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
