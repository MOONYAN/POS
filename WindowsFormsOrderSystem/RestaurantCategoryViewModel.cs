using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class RestaurantCategoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private Category _currentCategory;
        private Category _copyCategory;
        private const string DEFAULT = "";
        private BindingList<Meal> _currentUsedMealList;
        private string _frameText;
        private string _triggerText;
        private const string EDIT_CATEGORY = "Edit Category";
        private const string ADD_CATEGORY = "Add Category";
        private const string SAVE = "Save";
        private const string ADD = "Add";
        private bool _enableDelete;
        private bool _enableTrigger;
        private bool _enableAddMeal;
        private Mode _currentMode;
        private enum Mode
        {
            Default,
            Edit,
            Add
        }

        public RestaurantCategoryViewModel(Model model)
        {
            _model = model;
            _currentUsedMealList = new BindingList<Meal>();
            _copyCategory = new Category();
            _copyCategory._validChangedEvent += HandleValidChangedEvent;
            _model.Order._pickMealListChangedEvent += IdentifyEnabledDelete;
            SetDefaultMode();
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
            var query = mealList.ToList().Where(meal => meal.Category == _currentCategory);
            query.ToList().ForEach(meal => _currentUsedMealList.Add(meal));
        }

        // set category copy value
        private void SetCategoryCopyValue()
        {
            if (_currentCategory != null)
            {
                SetEditMode();
                CopyCategory.CopyValue(_currentCategory);
            }
            else
            {
                SetDefaultMode();
                _copyCategory.SetDefault();
            }
        }

        // delete category from category list
        public void DeleteCategory()
        {
            _model.DeleteCategory(_currentCategory);
        }

        // update Category Data
        private void UpdateCategoryData()
        {
            _currentCategory.CopyValue(_copyCategory);
        }

        // add new Category
        private void AddNewCategory()
        {
            _model.AddCategory(new Category(_copyCategory.Name));
        }

        //trigger Trigger Category Add Save
        public void TriggerCategoryAddSave()
        {
            switch (_currentMode)
            {
                case Mode.Edit:
                    {
                        UpdateCategoryData();
                        break;
                    }
                case Mode.Add:
                    {
                        AddNewCategory();
                        break;
                    }
            }
        }

        public Category CurrentCategory
        {
            set
            {
                _currentCategory = value;
                SetCurrentUsedMealList();
                SetCategoryCopyValue();
            }
        }

        public Category CopyCategory
        {
            get
            {
                return _copyCategory;
            }
        }

        public BindingList<Meal> CurrentUsedMealList
        {
            get
            {
                return _currentUsedMealList;
            }
        }

        public string FrameText
        {
            get
            {
                return _frameText;
            }
            set
            {
                _frameText = value;
                NotifyPropertyChanged();
            }
        }

        public string TriggerText
        {
            get
            {
                return _triggerText;
            }
            set
            {
                _triggerText = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableDelete
        {
            get
            {
                return _enableDelete;
            }
            private set
            {
                _enableDelete = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableTrigger
        {
            get
            {
                return _enableTrigger;
            }
            private set
            {
                _enableTrigger = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableAddMeal
        {
            get
            {
                return _enableAddMeal;
            }
            private set
            {
                _enableAddMeal = value;
                NotifyPropertyChanged();
            }
        }

        // Set Current Mode details
        private void SetCurrentMode(Mode mode, string frameText, string triggerText)
        {
            _currentMode = mode;
            FrameText = frameText;
            TriggerText = triggerText;
            EnableDelete = (mode == Mode.Edit);
            EnableTrigger = (mode == Mode.Edit);
        }

        // Set Current Mode to default mode
        private void SetDefaultMode()
        {
            SetCurrentMode(Mode.Default, EDIT_CATEGORY, SAVE);
            IdentifyEnableAddMeal();
        }

        // Set Current Mode to edit mode
        private void SetEditMode()
        {
            SetCurrentMode(Mode.Edit, EDIT_CATEGORY, SAVE);
            IdentifyEnabledDelete();
        }

        // Set Current Mode to add mode
        public void SetAddMode()
        {
            _copyCategory.SetDefault();
            SetCurrentMode(Mode.Add, ADD_CATEGORY, ADD);
        }

        //handler when category valid Changed
        private void HandleValidChangedEvent()
        {
            if (_currentMode != Mode.Default)
            {
                EnableTrigger = _copyCategory.IsValid;
            }
        }

        // identify whether it can can be delete
        private void IdentifyEnabledDelete()
        {
            List<Meal> pickMealList = _model.Order.PickMealList;
            EnableDelete = !pickMealList.Exists(meal => meal.Category == _currentCategory);
        }

        // identify whether it can be trigger add Meal mode
        private void IdentifyEnableAddMeal()
        {
            EnableAddMeal = _model.CategoryList.Count != 0;
        }
    }
}