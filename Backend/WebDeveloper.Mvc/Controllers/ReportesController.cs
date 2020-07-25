using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDeveloper.Core.ViewModels;
using WebDeveloper.Infra.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDeveloper.Mvc.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ChinookContext _context;
        public ReportesController(ChinookContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("/reportes/albumes-por-artista")]
        public IActionResult AlbumesPorArtista()
        {
            var items = _context.Artists.Select(a => new AlbumPorArtistaItemViewModel
            {
                ArtistId = a.ArtistId,
                ArtistName = a.Name,
                CantidadAlbumes = a.Albums.Count()
            }).ToList();

            // Crear el objeto view model que enviaremos a la vista
            var model = new AlbumPorArtistaViewModel { Title = $"Se tienen {items.Count}", Items = items };
            return View(model);
        }

        [Route("/reportes/albumes-por-artista-sp")]
        public IActionResult AlbumesPorArtistaSP()
        {
            var items = _context.ArtistCounts.FromSqlRaw("sp_algo").ToList();

            // Crear el objeto view model que enviaremos a la vista
            var model = new AlbumPorArtistaViewModel
            {
                Title = $"Se tienen {items.Count}",
                Items = items.Select(a => new AlbumPorArtistaItemViewModel
                {
                    ArtistId = a.ArtistId,
                    ArtistName = a.Nombre,
                    CantidadAlbumes = a.Cantidad
                }).ToList()
            };
            return View("AlbumesPorArtista", model);
        }
    }
}
