using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesMobileApp.Services.MovieDb
{
    public interface IDataDictionary
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
