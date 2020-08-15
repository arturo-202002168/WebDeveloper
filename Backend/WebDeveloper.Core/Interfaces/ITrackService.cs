using System;
using System.Collections.Generic;
using System.Text;
using WebDeveloper.Core.Entities;
using WebDeveloper.Core.ViewModels;

namespace WebDeveloper.Core.Interfaces
{
    public interface ITrackService
    {
        GetListViewModel<Track> GetList(int? page);
    }
}
