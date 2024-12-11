using AutoSalonProject2024.Models;
using Core.IRepositories;
using Core.IServices;
using Core.Repositories.DBRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;
        public CountryService()
        {
            _countryRepository = new CountryRepositoryDB();
        }
        public ObservableCollection<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }
    }
}
