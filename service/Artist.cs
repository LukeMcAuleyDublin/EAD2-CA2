using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace service
{

	public class Artist
	{

		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public int YearFormed { get; set; }
	}
}
