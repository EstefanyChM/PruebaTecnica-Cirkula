using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.Repository
{
	public interface UnitOfWork
	{
		Task SaveAsync();
	}
}
