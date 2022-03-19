using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.Controllers
{
	[Produces("application/json")]
	[Route("api/artists")]
	[ApiController]
	public class ArtistController : Controller
	{
		[HttpGet]
		public IEnumerable<Artist> GetArtists()
		{
			/*
			 * TODO: Query the Azure SQL database and return all arists
			 */
			
		}
	}
}
