using System;
using System.Linq;

namespace WebDeveloper.DbOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var context = new chinookContext();
            var albums = context.Album.ToList();
            foreach (var album in albums)
            {
                Console.WriteLine($"Nombre del album: {album.Title}");
                Console.WriteLine("Nombre del album: " + album.Title);
            }
        }
    }
}
