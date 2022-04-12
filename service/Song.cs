using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace service
{
	public class Song
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Length { get; set; }
		public string Genre { get; set; }
		public string Lyrics { get; set; }

		public int? ArtistID { get; set; }
	}
}
