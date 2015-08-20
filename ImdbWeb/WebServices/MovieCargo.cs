using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ImdbWeb.WebServices
{
	[DataContract]
	public class MovieCargo
	{
		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string ProductionYear { get; set; }
	}
}
