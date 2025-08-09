using Cirkula.Repository;
using DBCirkula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.RepositoryImpl
{
	public class UnitOfWorkImpl : UnitOfWork
	{
		private readonly _DBCirkulaContext dBCirkulaContext;

		public UnitOfWorkImpl(_DBCirkulaContext _DBCirkulaContext)
		{
			dBCirkulaContext = _DBCirkulaContext;
		}
		public async Task SaveAsync()
		{
			await dBCirkulaContext.SaveChangesAsync();
		}
	}
}
