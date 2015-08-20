using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ImdbWeb.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovieService" in both code and config file together.
	[ServiceContract]
	public interface IMovieService
	{
		[OperationContract]
		MovieCargo GetMovie(string id);

		[OperationContract]
		IEnumerable<MovieCargo> GetMovies();
	}

	
}
