using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void ValidChangedEventHandler();
        public event ValidChangedEventHandler _validChangedEvent;

        private string _name;
        private const string DEFAULT = "";
        private bool _isValid;

        public Category(string name = DEFAULT)
        {
            Name = name;
        }

        //set default value
        public void SetDefault()
        {
            Name = DEFAULT;
        }

        //copy attribute
        public void CopyValue(Category category)
        {
            Name = category.Name;
        }

        //Identify that is this a valid Category
        private void IdentifyValid()
        {
            IsValid = (_name != DEFAULT);
        }

        // helper   NotifyPropertyChanged
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = DEFAULT)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Notify _validChangedEvent
        private void NotifyValidChangedEvent()
        {
            if (_validChangedEvent != null)
            {
                _validChangedEvent();
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
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                    IdentifyValid();
                }                
            }
        }
    }
}