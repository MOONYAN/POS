using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void ShowMealListChangedEventHandler();
        public event ShowMealListChangedEventHandler _showMealListChangedEvent;
        private Model _model;
        private const string DEFAULT = "";
        private const int MEAL_UNIT = 9;
        private int _currentPage = 1;
        private int _mealCount = 0;
        private Category _currentCategory;
        private List<Meal> _currentShowMealList;
        private bool _enableLastPage;
        private bool _enableNextPage;
        private string _pageState;
        private const string FORMAT_STRING = "Page：{0}/{1}";

        public CustomerViewModel(Model model)
        {
            _model = model;
            _pageState = string.Format(FORMAT_STRING, 0, 0);
            _model._mealDeletedEvent += HandleMealDeletedEvent;
            _model._categoryDeletedEvent += HandleCategoryDeletedEvent;
            _model._mealAddedEvent += HandleMealAddedEvent;
            _currentShowMealList = new List<Meal>();
            InitializeMealListEventHandlers();
        }

        //Notify Show Meal List Changed Event
        private void NotifyShowMealListChangedEvent()
        {
            if (_showMealListChangedEvent != null)
            {
                _showMealListChangedEvent();
            }
        }

        //Handler Category Deleted Event
        private void HandleCategoryDeletedEvent(Category deleteCategory)
        {
            SetCurrentMealList();
        }

        // subscribe meal's categoryChangedEvent for initial meal list
        private void InitializeMealListEventHandlers()
        {
            BindingList<Meal> mealList = _model.MealList;
            mealList.ToList().ForEach(meal => meal._categoryChangedEvent += HandleMealCategoryChanged);
        }

        // handler  meal add event
        private void HandleMealAddedEvent(Meal newMeal)
        {
            newMeal._categoryChangedEvent += HandleMealCategoryChanged;
            SetCurrentMealList();
            NotifyShowMealListChangedEvent();
        }

        // handler  meal delete event
        private void HandleMealDeletedEvent(Meal deleteMeal)
        {
            SetCurrentMealList();
            NotifyShowMealListChangedEvent();
        }

        //handler when meal changed category
        private void HandleMealCategoryChanged()
        {
            SetCurrentMealList();
            NotifyShowMealListChangedEvent();
        }

        // helper   NotifyPropertyChanged
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = DEFAULT)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // set current meal list
        private void SetCurrentMealList()
        {
            _currentShowMealList = new List<Meal>();
            BindingList<Meal> mealList = _model.MealList;
            var query = mealList.ToList().Where(meal => meal.Category == _currentCategory);
            _currentShowMealList.AddRange(query);
            _mealCount = _currentShowMealList.Count;
            _currentPage = 1;            
        }

        public List<Meal> ShowMealList
        {
            get
            {
                var query = _currentShowMealList.Skip((_currentPage - 1) * MEAL_UNIT).Take(MEAL_UNIT);
                return query.ToList();
            }
        }

        // update page state
        void UpdateCurrentPageState()
        {
            EnableLastPage = !(_currentPage == 1);
            EnableNextPage = _currentPage * MEAL_UNIT < _mealCount;
            PageState = string.Format(FORMAT_STRING, _currentPage, (_mealCount - 1) / MEAL_UNIT + 1);
        }

        // change to last page
        public void ChangeLastPage()
        {
            _currentPage--;
            UpdateCurrentPageState();
            NotifyShowMealListChangedEvent();
        }

        // change to next page
        public void ChangeNextPage()
        {
            _currentPage++;
            UpdateCurrentPageState();
            NotifyShowMealListChangedEvent();
        }

        public Category CurrentCategory
        {
            get
            {
                return _currentCategory;
            }
            set
            {
                _currentCategory = value;
                SetCurrentMealList();
                UpdateCurrentPageState();
                NotifyShowMealListChangedEvent();
            }
        }

        public string PageState
        {
            get
            {
                return _pageState;
            }
            set
            {
                _pageState = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableLastPage
        {
            get
            {
                return _enableLastPage;
            }
            set
            {
                _enableLastPage = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableNextPage
        {
            get
            {
                return _enableNextPage;
            }
            set
            {
                _enableNextPage = value;
                NotifyPropertyChanged();       
            }
        }
    }
}