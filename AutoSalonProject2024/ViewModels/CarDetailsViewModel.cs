using AutoSalonProject2024.Commands;
using AutoSalonProject2024.Models;
using Core.IServices;
using Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoSalonProject2024.ViewModels
{
    public class CarDetailsViewModel : INotifyPropertyChanged
    {
        private int picIndex = 0;
        private byte[] _selectedPic;
        public Car Car { get; set; }
        private ICarService _carService;

        public byte[] SelectedPicture {

            get
            {
                return _selectedPic;
            }

            set
            {
                _selectedPic = value;
                propertValueChanged(nameof(SelectedPicture));
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void propertValueChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand nextPicture { get; set; }
        public ICommand previousPicture { get; set; }

        public CarDetailsViewModel(int id)
        {
            _carService = new CarService();
            Car = _carService.GetCarById(id);
            SelectedPicture = Car.Images[0];
            nextPicture = new RelayCommand(displayNextPicture, canDisplayNextPicture);
            previousPicture = new RelayCommand(displayPreviousPicture, canDisplayPreviousPicture);
        }

        private bool canDisplayPreviousPicture(object obj)
        {
            return true;
        }

        private void displayPreviousPicture(object obj)
        {
            if (picIndex > 0)
            {
                SelectedPicture = Car.Images[--picIndex];
                Trace.WriteLine(picIndex);
            }
        }

        private bool canDisplayNextPicture(object obj)
        {
            return true;
        }

        private void displayNextPicture(object obj)
        {
            if (picIndex < Car.Images.Count() - 1)
            {
                SelectedPicture = Car.Images[++picIndex];
                Trace.WriteLine(picIndex);
            }
        }
    }
}
