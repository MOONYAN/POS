using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class BillRecord : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Meal _meal;
        private const string DELETE = "Delete";
        private string _name;
        private string _category;
        private int _price;
        private int _quantity;
        private int _subtotal;
        private const string DEFAULT = "";
        const string PROPERTY_NAME = "Name";
        const string PROPERTY_CATEGORY = "Category";
        const string PROPERTY_PRICE = "Price";

        public BillRecord(Meal meal, int quantity)
        {
            _meal = meal;
            _name = meal.Name;
            _category = meal.Category.Name;
            _price = meal.Price;
            _quantity = quantity;
            _meal.PropertyChanged += HandleMealPropertyChanged;
        }

        //handler   when meal change
        private void HandleMealPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PROPERTY_NAME)
            {
                Name = _meal.Name;
            }
            if (e.PropertyName == PROPERTY_CATEGORY)
            {
                Category = _meal.Category.Name;
            }
            if (e.PropertyName == PROPERTY_PRICE)
            {
                Price = _meal.Price;
            }
        }

        // get string[] list from .csv file
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = DEFAULT)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Delete
        {
            get
            {
                return DELETE;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                NotifyPropertyChanged();
                _name = value;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
            private set
            {
                _category = value;
                NotifyPropertyChanged();
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
            private set
            {
                _price = value;
                Subtotal = _quantity * _price;
                NotifyPropertyChanged();
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                Subtotal = _quantity * _price;
                NotifyPropertyChanged();
            }
        }

        public int Subtotal
        {
            get
            {
                return _subtotal;
            }
            private set
            {
                _subtotal = value;
                NotifyPropertyChanged();
            }
        }
    }
}