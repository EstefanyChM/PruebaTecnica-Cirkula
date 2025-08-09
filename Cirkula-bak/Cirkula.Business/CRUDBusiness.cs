using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.Business
{
	/// <summary>
	/// MÉTODOS CRUD EN LA CAPA BUSINESS
	/// </summary>
	/// <typeparam name="TRequest">REQUEST</typeparam>
	/// <typeparam name="TResponse">RESPONSE</typeparam>
	public interface CRUDBusiness <TRequest,TResponse>
	{
		Task<IEnumerable<TResponse>> GetAllAsync();
		Task<TResponse> GetByIdAsync(int id);
		Task<TResponse> CreateAsync(TRequest entity);
		Task UpdateAsync(TRequest entity);
		Task DeleteAsync(int id);
	}
}
