using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ICarModelService
    {
        public ObservableCollection<CarModel> GetAllModels();
    }
}
