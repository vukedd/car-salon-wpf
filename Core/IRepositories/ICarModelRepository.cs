﻿using AutoSalonProject2024.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ICarModelRepository
    {
        public ObservableCollection<CarModel> GetAllModels();
        public void AddCarModel(CarModel CarModel);
        void DeleteCarModel(CarModel carModel);
    }
}
