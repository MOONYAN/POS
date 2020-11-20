using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class Meal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void ValidChangedEventHandler();
        public event ValidChangedEventHandler _validChangedEvent;
        public delegate void CategoryChangedEventHandler();
        public event CategoryChangedEventHandler _categoryChangedEvent;
        private string _name;
        private int _price;
        private Category _category;
        private string _path;
        private string _description;
        private const string DEFAULT = "";
        private bool _isValid;

        public Meal()
        {
            _name = DEFAULT;
            _price = 0;
            _category = new Category();
            _path = DEFAULT;
            _description = DEFAULT;
            _isValid = false;
            _category.PropertyChanged += HandleCategoryPropertyChanged;
        }

        public Meal(string name, Category category, int price, string path, string description = DEFAULT)
        {
            _name = name;
            _price = price;
            _category = category;
            _path = path;
            _description = description;
            IdentifyValid();
            _category.PropertyChanged += HandleCategoryPropertyChanged;
        }

        //set default value
        public void SetDefault()
        {
            _name = DEFAULT;
            _price = 0;
            _category = new Category();
            _path = DEFAULT;
            _description = DEFAULT;
            /*Name = DEFAULT;
            Price = 0;
            Category = new Category();
            Path = DEFAULT;
            Description = DEFAULT;*/
            NotifyAllPropertyChanged();
        }

        //copy attribute
        public void CopyValue(Meal meal)
        {
            _name = meal.Name;
            _price = meal.Price;
            _category = meal.Category;
            _path = meal.Path;
            _description = meal.Description;
            /*Name = meal.Name;
            Price = meal.Price;
            Category = meal.Category;
            Path = meal.Path;
            Description = meal.Description;*/
            NotifyAllPropertyChanged();
        }
               
        //handler when category change
        private void HandleCategoryPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Category = _category;
        }

        // helper   Notify Property Changed
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = DEFAULT)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Notify All Property Changed
        void NotifyAllPropertyChanged()
        {
            Name = _name;
            Price = _price;
            Category = _category;
            Path = _path;
            Description = _description;
            IdentifyValid();
        }

        //Identify that is this a valid meal
        private void IdentifyValid()
        {
            IsValid = (_name != DEFAULT) && (_price != 0) && (_category != null) && (_path != DEFAULT);
        }

        // Notify Valid Changed Event
        private void NotifyValidChangedEvent()
        {
            if (_validChangedEvent != null)
            {
                _validChangedEvent();
            }
        }

        //Notify Category Changed Event
        private void NotifyCategoryChangedEvent()
        {
            if (_categoryChangedEvent != null)
            {
                _categoryChangedEvent();
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                NotifyValidChangedEvent();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
                IdentifyValid();
            }
        }

        public Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                NotifyPropertyChanged();
                NotifyCategoryChangedEvent();
                IdentifyValid();
            }
        }
        
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                NotifyPropertyChanged();
                IdentifyValid();
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                NotifyPropertyChanged();
                IdentifyValid();
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged();
            }
        }
    }
}