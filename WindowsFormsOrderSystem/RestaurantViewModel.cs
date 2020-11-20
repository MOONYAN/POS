using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{

    class RestaurantViewModel : INotifyPropertyChanged
    {
        public delegate void CurrentMealChangedEventHandler(Meal currentMeal);
        public event CurrentMealChangedEventHandler _currentMealChangedEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private Category _currentCategory;
        private Category _copyCategory;
        private Meal _currentMeal;
        private const string DEFAULT = "";
        private BindingList<Meal> _currentUsedMealList;
        private string _currentState;
        private string _currentText;
        private const string EDIT_CATEGORY = "Edit Category";
        private const string ADD_CATEGORY = "Add Category";
        private const string SAVE = "Save";
        private const string ADD = "Add";

        public RestaurantViewModel(Model model)
        {
            _model = model;
            _currentUsedMealList = new BindingList<Meal>();
            _copyCategory = new Category();
            CurrentState = EDIT_CATEGORY;
            CurrentText = SAVE;
        }

        // helper   NotifyPropertyChanged
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = DEFAULT)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // set current uesd meal list by selected category
        private void SetCurrentUsedMealList()
        {
            BindingList<Meal> mealList = _model.MealList;
            _currentUsedMealList.Clear();
            foreach (Meal meal in mealList)
            {
                if (meal.Category == _currentCategory)
                {
                    _currentUsedMealList.Add(meal);
                }
            }
        }

        // set copy value
        private void SetCopyValue()
        {
            if (_currentCategory != null)
            {
                CopyCategory.CopyValue(_currentCategory);
            }
            else
            {
                _copyCategory.SetDefault();
            }
        }

        // delete category from category list
        public void DeleteCategory()
        {
            _model.DeleteCategory(_currentCategory);
        }

        // update Category Data
        public void UpdateCategoryData()
        {
            _currentCategory.CopyValue(_copyCategory);
        }

        // add new Category
        private void AddNewCategory()
        {
            _model.AddCategory(_copyCategory.Name);
        }

        //trigger Trigger Category Add Save
        public void TriggerCategoryAddSave()
        {
            switch (_currentState)
            {
                case EDIT_CATEGORY:
                    {
                        UpdateCategoryData();
                        break;
                    }
                case ADD_CATEGORY:
                    {
                        AddNewCategory();
                        //CurrentState = EDIT_CATEGORY;
                        break;
                    }
            }
        }

        public Meal CurrentMeal
        {
            get
            {
                return _currentMeal;
            }
            set
            {
                _currentMeal = value;
                if (_currentMealChangedEvent != null)
                {
                    _currentMealChangedEvent(_currentMeal);
                }
            }
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
                CurrentState = EDIT_CATEGORY;
                CurrentText = SAVE;
                SetCurrentUsedMealList();
                SetCopyValue();
            }
        }

        public Category CopyCategory
        {
            get
            {
                return _copyCategory;
            }
            set
            {
                _copyCategory = value;
            }
        }

        public string CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
                NotifyPropertyChanged();
            }
        }

        public string CurrentText
        {
            get
            {
                return _currentText;
            }
            set
            {
                _currentText = value;
                NotifyPropertyChanged();
            }
        }

        public BindingList<Meal> CurrentUsedMealList
        {
            get
            {
                return _currentUsedMealList;
            }
        }

        // set add state
        public void SetAddState()
        {
            CurrentState = ADD_CATEGORY;
            CurrentText = ADD;
        }
    }
}