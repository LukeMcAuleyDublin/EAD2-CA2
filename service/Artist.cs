using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service
{
	public class Artist
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public int YearFormed { get; set; }

		public virtual ICollection<Song> Songs { get; set; }
	}
}
