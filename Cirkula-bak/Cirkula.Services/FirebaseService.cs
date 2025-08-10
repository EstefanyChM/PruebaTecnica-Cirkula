using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.Services
{
	public interface FirebaseService
	{
		Task<string> UploadFileAsync(Stream file, string fileName, string folder);

	}
}
