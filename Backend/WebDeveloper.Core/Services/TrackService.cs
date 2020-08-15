using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDeveloper.Core.Entities;
using WebDeveloper.Core.Interfaces;
using WebDeveloper.Core.ViewModels;

namespace WebDeveloper.Core.Services
{
    public class TrackService : ITrackService
    {
        private readonly IChinookContext _chinookContext;
        public TrackService(IChinookContext chinookContext)
        {
            _chinookContext = chinookContext;
        }

        public GetListViewModel<Track> GetList(int? page)
        {
            // Por ahora el tamanio de pagina sera fijo de 10
            var pageSize = 10;
            if(!page.HasValue || page == 1)
            {
                return new GetListViewModel<Track>
                {
                    Items = _chinookContext.Tracks.Take(pageSize).ToList(),
                    NextPage = 2
                };
            }

            if(page > 1)
            {
                // Cuantos registros no debemos considerar
                var skip = (page.Value - 1) * pageSize;
                return new GetListViewModel<Track>
                {
                    Items = _chinookContext.Tracks.Skip(skip).Take(pageSize).ToList(),
                    NextPage = page.Value + 1
                };
            }

            return null;
        }
    }
}
