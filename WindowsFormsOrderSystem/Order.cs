using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void PickMealListChangedEventHandler();
        public event PickMealListChangedEventHandler _pickMealListChangedEvent;
        private BindingList<BillRecord> _billRecordList = new BindingList<BillRecord>();
        private List<Meal> _pickMealList = new List<Meal>();
        private string _totalCost = string.Empty;
        private const string FORMAT_STRING = "Total：{0}：NTD";
        private const string DEFAULT = "";

        public Order()
        {
            TotalCost = string.Format(FORMAT_STRING, 0);
        }

        // helper   Notify Property Changed
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = DEFAULT)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //helper notify pckeMealList Changed Event
        private void NotifyPickMealListChangedEvent()
        {
            if (_pickMealListChangedEvent != null)
            {
                _pickMealListChangedEvent();
            }
        }

        //Add meal to orderer's list
        public void PickMeal(Meal meal)
        {
            IdentifyPickNewMeal(meal);
            int index = _pickMealList.IndexOf(meal);
            _billRecordList[index].Quantity++;
            NotifyPickMealListChangedEvent();
        }

        //Identify Pick New Meal
        private void IdentifyPickNewMeal(Meal meal)
        {
            if (!_pickMealList.Contains(meal))
            {
                _pickMealList.Add(meal);
                BillRecord bill = new BillRecord(meal, 0);
                bill.PropertyChanged += HandleBillPropertyChanged;
                _billRecordList.Add(bill);
            }
        }

        //handler bill property changed
        private void HandleBillPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            const string PROPERTY_SUBTOTAL = "Subtotal";
            if (e.PropertyName == PROPERTY_SUBTOTAL)
            {
                CalculateTotalCost();
            }
        }

        //handler calculate total cost
        private void CalculateTotalCost()
        {
            int total = 0;
            _billRecordList.ToList().ForEach(bill => total += bill.Subtotal);
            TotalCost = string.Format(FORMAT_STRING, total);
        }

        //Remove meal form orderer's list
        public void RemoveMeal(int index)
        {
            _pickMealList.RemoveAt(index);
            _billRecordList.RemoveAt(index);
            CalculateTotalCost();
            NotifyPickMealListChangedEvent();
        }

        public string TotalCost
        {
            get
            {
                return _totalCost;
            }
            private set
            {
                _totalCost = value;
                NotifyPropertyChanged();
            }
        }

        public List<Meal> PickMealList
        {
            get
            {
                return _pickMealList;
            }
        }

        public BindingList<BillRecord> BillRecordList
        {
            get
            {
                return _billRecordList;
            }
        }
    }
}