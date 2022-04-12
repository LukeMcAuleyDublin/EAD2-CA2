using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using service;

namespace service.Data
{
    public class serviceContext : DbContext
    {
        public serviceContext (DbContextOptions<serviceContext> options)
            : base(options)
        {
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
