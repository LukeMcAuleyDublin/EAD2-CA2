using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System;

namespace database
{
    public class Artist
    {
        public int ID { get; set; }                 // PK and identity
        public string Name { get; set; }            // null
        public string Bio { get; set; }           // null
        public int YearFormed { get; set; }

        // navigation property to modules that Lecturer teaches, virtual => lazy loading  
        public virtual ICollection<Song> Songs { get; set; }
    }

    public class Song
    {
        public int ID { get; set; }                             // PK and identity
        public string Name { get; set; }                        // null
        public string Length { get; set; }                        // not null, use int? for null
        public string Genre { get; set; }
        public string Lyrics { get; set; }

        // foreign key property, null, follows convention for naming
        public int? ArtistID { get; set; }
        // update relationship through this property, not through navigation property
        // int would not allow null for LecturerID                 

        // navigation property to Lecturer for this module
        public virtual Artist Artist { get; set; }           // virtual enables "lazy loading" 
    }

    // context class
    public class ArtistInfoContext : DbContext
    {
        // localDB connection string
        // c:\users\gary\CollegeDB1.mdf
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:ead2-ca2-server.database.windows.net,1433;Initial Catalog=EAD2-DB;Persist Security Info=False;User ID=EAD2CA2Admin;Password=CostaCoffee22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }


    class ArtistRepository
    {
        // print lecturers, their ids, names, and the names of modules they teach 
        public void DoArtistQuery()
        {
            using ArtistInfoContext db = new ();

            var artists = db.Artists.OrderBy(l => l.ID).Select(l => new { Id = l.ID, Name = l.Name, Songs = l.Songs });
            Console.WriteLine(artists.ToQueryString());

            Console.WriteLine("\nArtists:");
            foreach (var artist in artists)
            {
                Console.WriteLine("id: " + artist.Id + " name: " + artist.Name);
                Console.WriteLine("Created these songs: ");

                // Modules is a navigation propery of type ICollection<Module>
                var artistSongs = artist.Songs;
                foreach (var artistSong in artistSongs)
                {
                    Console.WriteLine(artistSong.Name);
                }
            }
        }

        // prints the ID and name of each module and the name of the lecturer who teaches it
        public void DoSongQuery()
        {
            using ArtistInfoContext db = new ArtistInfoContext();

            // select all modules, ordered by module name
            var songs = db.Songs.Include(m => m.Artist).OrderBy(song => song.ID);       // load

            Console.WriteLine("\nSongs:");
            foreach (var song in songs)
            {
                Console.WriteLine("id: " + song.ID + " name: " + song.Name + " ");

                if (song.ArtistID != null)
                {
                    // Lecturer is a navigation property of type Lecturer
                    Console.WriteLine(" Song created by: " + song.Artist.Name);
                }
            }
        }

        // add a lecturer, modules being taught left null for moment
        public void AddArtist(Artist artist)
        {
            using ArtistInfoContext db = new ArtistInfoContext();

            try
            {
                // add and save
                db.Artists.Add(artist);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // add a module, contains lecturerID
        public void AddSong(Song song)
        {
            using ArtistInfoContext db = new ();

            try
            {
                // add and save
                db.Songs.Add(song);
                db.SaveChanges();
                // navigation properties updated on both sides
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static class Test
        {
            static void Main()
            {

                ArtistRepository repository = new ();

                Artist beatles = new Artist() { Name = "The Beatles", Bio = "The Beatles were an English rock band, formed in Liverpool, that comprised John Lennon, Paul McCartney, George Harrison and Ringo Starr.",
                                                YearFormed = 1960,};
                Artist fleetwoodmac = new Artist()
                {
                    Name = "Fleetwood Mac",
                    Bio = "Fleetwood Mac are a British-American rock band, formed in London. Fleetwood Mac were founded by guitarist Peter Green, drummer Mick Fleetwood and guitarist Jeremy Spencer, before bassist John McVie joined the line-up.",
                    YearFormed = 1967,
                };
                repository.AddArtist(beatles);         // ID now assigned
                repository.AddArtist(fleetwoodmac);

                // teaches 2 modules
                Song lovemedo = new () { Name = "Love Me Do", Length = "2:22", Genre = "Rock", ArtistID = beatles.ID };
                Song letitbe = new () { Name = "Let It Be", Length = "4:03", Genre = "Rock", ArtistID = beatles.ID };
                Song twoofus = new() { Name = "Two Of Us", Length = "3:37", Genre = "Rock", ArtistID = beatles.ID };

                Song albatross = new() { Name = "Albatross", Length = "3:07", Genre = "Blues", ArtistID = fleetwoodmac.ID };
                Song everywhere = new() { Name = "Everywhere", Length = "3:41", Genre = "Pop", ArtistID = fleetwoodmac.ID };

                repository.AddSong(lovemedo);
                repository.AddSong(letitbe);
                repository.AddSong(twoofus);

                repository.AddSong(albatross);
                repository.AddSong(everywhere);

                repository.DoArtistQuery();
                repository.DoSongQuery();

                Console.ReadLine();
            }
        }
    }
}
