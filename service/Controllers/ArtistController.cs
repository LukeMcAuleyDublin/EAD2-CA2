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

		[HttpGet("{id}")] // Return artist information on given artist ID.
		public IEnumerable<Artist> getArtistByID()
		{
			/*
			 * TODO: Query the database and return artist where ID is met.
			 */
		}

		[HttpGet("/songs")] // Returns all songs in the database.
		public IEnumerable<Song> getSongs()
		{
			/*
			 * TODO: Query the database and return all objects of type song
			 */
		}

		[HttpGet("songs/{id}")] // Return songs by artist of given ID.
		public IEnumerable<Song> getSongsByArtist()
		{
			/* 
			 * TODO: Query the database and return all songs by artist with given ID.
			 */
		}
	}
}
