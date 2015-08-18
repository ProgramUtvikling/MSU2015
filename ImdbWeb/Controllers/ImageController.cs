using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class ImageController : Controller
	{
		[Route("Image/{format}/{id}.jpg")]
		public async Task<ActionResult> CreateImage(string format, string id)
		{
			// koble til en storage-account
			var connectionString = CloudConfigurationManager.GetSetting("msu2015_AzureStorageConnectionString");
			var acct = CloudStorageAccount.Parse(connectionString);

			// åpne en konteiner
			var client = acct.CreateCloudBlobClient();

			var container = client.GetContainerReference("covers");
			
			// hente en fil
			var blob = container.GetBlockBlobReference($"{id}.jpg");

			if (!await blob.ExistsAsync()) return HttpNotFound();

			using (var ms = new MemoryStream())
			{
				// laste ned som stream
				await blob.DownloadToStreamAsync(ms);


				var img = new WebImage(ms);

				switch (format.ToLower())
				{
					case "thumb":
						img.Resize(100, 1000)
							.Write();
						return new EmptyResult();

					case "medium":
						img.Resize(300, 3000)
							.AddTextWatermark("Ingars Movie Database")
							.AddTextWatermark("Ingars Movie Database", "White", padding: 7)
							.Write();
						return new EmptyResult();

					default:
						return HttpNotFound();
				}
			}
		}
	}
}