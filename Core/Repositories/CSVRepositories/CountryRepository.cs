using AutoSalonProject2024.Models;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.CSVRepositories
{
    public class CountryRepository : ICountryRepository
    {
        public ObservableCollection<Country> GetAllCountries()
        {
            throw new NotImplementedException();
        }
    }
}
