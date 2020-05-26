using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class DishViewModel : INotifyPropertyChanged
    {

        private RestaurantManager restaurantManager;
        private double _dishPrice;
        private string _dishName;
        private string _dishDesc;
        public int SelectedIndexCategory { get; set; }

        public ICommand addDish { get; }


        public DishViewModel(RestaurantManager rm)
        {
            this.restaurantManager = rm;
            DishPrice = 0.00;
            addDish = new DelegateCommand(addDishCommand);

        }

        public double DishPrice
        {
            get { return _dishPrice; }
            set
            {
                if (_dishPrice != value)
                {
                    _dishPrice = value;
                    PropertyChangedHandler("DishPrice");
                }
            }
        }

        public string DishName
        {
            get { return _dishName; }
            set
            {
                if (_dishName != value)
                {
                    _dishName = value;
                    PropertyChangedHandler("DishName");
                }
            }
        }

        public string DishDesc
        {
            get { return _dishDesc; }
            set
            {
                if (_dishDesc != value)
                {
                    _dishDesc = value;
                    PropertyChangedHandler("DishDesc");
                }
            }
        }

        private void addDishCommand()
        {
            restaurantManager.CreateDish(DishName, DishDesc, null, (Category)SelectedIndexCategory, DishPrice);

        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedHandler(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
    }
}
