using Cirkula.Repository;
using DBCirkula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.RepositoryImpl
{
	public class StoreRepositoryImpl : CRUDRepositoryImpl<Store>, StoreRepository
	{
		private readonly _DBCirkulaContext dBCirkulaContext;

		public StoreRepositoryImpl(_DBCirkulaContext _DBCirkulaContext): base (_DBCirkulaContext) 
		{
			dBCirkulaContext = _DBCirkulaContext;
		}
	}
}
