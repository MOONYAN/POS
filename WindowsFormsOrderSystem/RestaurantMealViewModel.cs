using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class RestaurantMealViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private Meal _currentMeal;
        private Meal _copyMeal;
        private const string DEFAULT = "";
        private BindingList<Meal> _currentUsedMealList;
        private string _frameText;
        private string _triggerText;
        private const string EDIT_MEAL = "Edit Meal";
        private const string ADD_MEAL = "Add Meal";
        private const string SAVE = "Save";
        private const string ADD = "Add";
        private bool _enableDelete;
        private bool _enableTrigger;        
        private Mode _currentMode;
        private enum Mode
        {
            Default,
            Edit,
            Add
        }

        public RestaurantMealViewModel(Model model)
        {
            _model = model;
            _currentUsedMealList = new BindingList<Meal>();
            _copyMeal = new Meal();
            _copyMeal._validChangedEvent += HandleValidChangedEvent;
            _model.Order._pickMealListChangedEvent += IdentifyEnabledDelete;
            SetDefaultMode();
        }

        // helper   NotifyPropertyChanged
        void NotifyPropertyChanged([CallerMemberName] string propertyName = DEFAULT)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // set meal copy value
        private void SetMealCopyValue()
        {
            if (_currentMeal != null)
            {
                SetEditMode();
                CopyMeal.CopyValue(_currentMeal);
            }
            else
            {
                SetDefaultMode();
                _copyMeal.SetDefault();
            }
        }

        // delete meal from category list
        public void DeleteMeal()
        {
            _model.DeleteMeal(_currentMeal);
        }

        //Update Meal Data
        private void UpdateMealData()
        {
            _currentMeal.CopyValue(_copyMeal);
        }

        // add new Meal
        private void AddNewMeal()
        {
            _model.AddMeal(new Meal(_copyMeal.Name, _copyMeal.Category, _copyMeal.Price, _copyMeal.Path, _copyMeal.Description));
        }

        //trigger Trigger Meal Add Save
        public void TriggerMealAddSave()
        {
            switch (_currentMode)
            {
                case Mode.Edit:
                    {
                        UpdateMealData();
                        break;
                    }
                case Mode.Add:
                    {
                        AddNewMeal();
                        break;
                    }
            }
        }

        public Meal CurrentMeal
        {
            set
            {
                _currentMeal = value;
                SetMealCopyValue();
            }
        }

        public Meal CopyMeal
        {
            get
            {
                return _copyMeal;
            }
        }

        public string FrameText
        {
            get
            {
                return _frameText;
            }
            private set
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
            private set
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
            SetCurrentMode(Mode.Default, EDIT_MEAL, SAVE);
        }

        // Set Current Mode to edit mode
        private void SetEditMode()
        {
            SetCurrentMode(Mode.Edit, EDIT_MEAL, SAVE);
            IdentifyEnabledDelete();
        }

        // Set Current Mode to add mode
        public void SetAddMode()
        {
            _copyMeal.SetDefault();
            SetCurrentMode(Mode.Add, ADD_MEAL, ADD);
        }

        // identify whether it can can be delete
        private void IdentifyEnabledDelete()
        {
            List<Meal> pickMealList = _model.Order.PickMealList;
            EnableDelete = !pickMealList.Contains(_currentMeal);
        }

        //handler when category valid Changed
        private void HandleValidChangedEvent()
        {
            if (_currentMode != Mode.Default)
            {
                EnableTrigger = _copyMeal.IsValid;
            }
        }
    }
}