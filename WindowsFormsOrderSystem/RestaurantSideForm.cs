using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOrderSystem
{
    public partial class RestaurantSideForm : Form
    {
        private RestaurantCategoryViewModel _viewCategoryModel;
        private RestaurantMealViewModel _viewMealModel;
        private Model _model;
        private readonly string _projectPath;
        const string PROPERTY_TEXT = "Text";
        const string PROPERTY_ENABLED = "Enabled";
        const string PROPERTY_FRAME_TEXT = "FrameText";
        const string PROPERTY_TRIGGER_TEXT = "TriggerText";
        const string PROPERTY_ENABLE_DELETE = "EnableDelete";
        const string PROPERTY_ENABLE_TRIGGER = "EnableTrigger";

        public RestaurantSideForm(Model model)
        {
            InitializeComponent();
            _model = model;
            _viewCategoryModel = new RestaurantCategoryViewModel(_model);
            _viewMealModel = new RestaurantMealViewModel(_model);
            DirectoryInfo startUpPath = new DirectoryInfo(Application.StartupPath);
            _projectPath = startUpPath.Parent.Parent.Parent.FullName;
        }

        // handler load form
        private void LoadRestaurantSideForm(object sender, EventArgs e)
        {
            InitializeCategoryTabPageBindings();
            InitializeMealTabPageBindings();
            _categoryListBox.ClearSelected();
            _mealListBox.ClearSelected();
            _categoryUsedMealListBox.ClearSelected();
            //_mealCategoryComboBox.SelectedIndex = 0;
        }

        //Initialize Category Tabpage Bindings
        private void InitializeCategoryTabPageBindings()
        {
            const string PROPERTY_CATEGORY_NAME = "CopyCategory.Name";
            const string PROPERTY_ENABLE_ADD_MEAL = "EnableAddMeal";
            _categoryListBox.DataSource = _model.CategoryList;
            _categoryUsedMealListBox.DataSource = _viewCategoryModel.CurrentUsedMealList;
            _categoryNameTextBox.DataBindings.Add(PROPERTY_TEXT, _viewCategoryModel, PROPERTY_CATEGORY_NAME, true, DataSourceUpdateMode.OnPropertyChanged);
            _categoryGroupBox.DataBindings.Add(PROPERTY_TEXT, _viewCategoryModel, PROPERTY_FRAME_TEXT);
            _categoryAddSaveButton.DataBindings.Add(PROPERTY_TEXT, _viewCategoryModel, PROPERTY_TRIGGER_TEXT);
            _deleteCategoryButton.DataBindings.Add(PROPERTY_ENABLED, _viewCategoryModel, PROPERTY_ENABLE_DELETE);
            _categoryAddSaveButton.DataBindings.Add(PROPERTY_ENABLED, _viewCategoryModel, PROPERTY_ENABLE_TRIGGER);
            _addMealModeButton.DataBindings.Add(PROPERTY_ENABLED, _viewCategoryModel, PROPERTY_ENABLE_ADD_MEAL);
        }

        //Initialize MealTabpage Bindings
        private void InitializeMealTabPageBindings()
        {
            const string PROPERTY_MEAL_NAME = "CopyMeal.Name";
            const string PROPERTY_MEAL_PRICE = "CopyMeal.Price";
            const string PROPERTY_MEAL_PATH = "CopyMeal.Path";
            const string PROPERTY_MEAL_DESCRIPTION = "CopyMeal.Description";
            const string PROPERTY_MEAL_CATEGORY = "CopyMeal.Category";
            const string PROPERTY_SELECTION = "SelectedItem";
            _mealListBox.DataSource = _model.MealList;
            _mealCategoryComboBox.DataSource = _model.CategoryList;
            _mealCategoryComboBox.DataBindings.Add(PROPERTY_SELECTION, _viewMealModel, PROPERTY_MEAL_CATEGORY, true, DataSourceUpdateMode.OnPropertyChanged);
            _mealNameTextBox.DataBindings.Add(PROPERTY_TEXT, _viewMealModel, PROPERTY_MEAL_NAME, true, DataSourceUpdateMode.OnPropertyChanged);
            _mealPriceTextBox.DataBindings.Add(PROPERTY_TEXT, _viewMealModel, PROPERTY_MEAL_PRICE, true, DataSourceUpdateMode.OnPropertyChanged);
            _mealPathTextBox.DataBindings.Add(PROPERTY_TEXT, _viewMealModel, PROPERTY_MEAL_PATH, true, DataSourceUpdateMode.OnPropertyChanged);
            _mealDescriptionTextBox.DataBindings.Add(PROPERTY_TEXT, _viewMealModel, PROPERTY_MEAL_DESCRIPTION, true, DataSourceUpdateMode.OnPropertyChanged);
            _mealGroupBox.DataBindings.Add(PROPERTY_TEXT, _viewMealModel, PROPERTY_FRAME_TEXT);
            _mealAddSaveButton.DataBindings.Add(PROPERTY_TEXT, _viewMealModel, PROPERTY_TRIGGER_TEXT);
            _deleteMealButton.DataBindings.Add(PROPERTY_ENABLED, _viewMealModel, PROPERTY_ENABLE_DELETE);
            _mealAddSaveButton.DataBindings.Add(PROPERTY_ENABLED, _viewMealModel, PROPERTY_ENABLE_TRIGGER);
        }

        // handler click delete category button
        private void ClickDeleteCategoryButton(object sender, EventArgs e)
        {
            _mealListBox.ClearSelected();
            _viewCategoryModel.DeleteCategory();
            _categoryListBox.ClearSelected();
        }

        //handler change category list box select value
        private void ChangeCategoryListBoxSelectValue(object sender, EventArgs e)
        {
            _viewCategoryModel.CurrentCategory = (Category)_categoryListBox.SelectedItem;
        }

        //handler Click Category Add Save Button
        private void ClickCategoryAddSaveButton(object sender, EventArgs e)
        {
            _viewCategoryModel.TriggerCategoryAddSave();
            _categoryListBox.ClearSelected();
        }

        //handler Click Meal Add Save Button
        private void ClickMealAddSaveButton(object sender, EventArgs e)
        {
            _viewMealModel.TriggerMealAddSave();
            _mealListBox.ClearSelected();
        }

        //handler Click Add Category Mode
        private void ClickAddCategoryMode(object sender, EventArgs e)
        {
            _categoryListBox.ClearSelected();
            _viewCategoryModel.SetAddMode();
        }

        //handler Click Add Meal Mode
        private void ClickAddMealMode(object sender, EventArgs e)
        {
            _viewMealModel.SetAddMode();
        }

        //handler Change Category List Box Select Value
        private void ChangeMealListBoxSelectValue(object sender, EventArgs e)
        {
            _viewMealModel.CurrentMeal = (Meal)_mealListBox.SelectedItem;
        }

        //handler Click Delete Meal Button
        private void ClickDeleteMealButton(object sender, EventArgs e)
        {
            _viewMealModel.DeleteMeal();
            _mealListBox.ClearSelected();
        }

        // handler accessed file dialog FileName
        private void NotifyFileOK(object sender, CancelEventArgs e)
        {
            const string SLASH = "/";
            const string BACK_SLASH = "\\";
            const string IMAGE = "image";
            string absolutePath = _openFileDialog.FileName;
            if (absolutePath.Contains(_projectPath + BACK_SLASH + IMAGE))
            {
                string remainderPath = absolutePath.Replace(_projectPath, string.Empty);
                _mealPathTextBox.Text = remainderPath.Replace(BACK_SLASH, SLASH);
            }
            else
            {
                const string TITLE = "ERROR";
                const string MESSAGE = "Please select from relative path.";
                MessageBox.Show(MESSAGE, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // handler Click Browse Button to select backgroundImade
        private void ClickBrowseButton(object sender, EventArgs e)
        {
            _openFileDialog.InitialDirectory = _projectPath;
            _openFileDialog.ShowDialog();
        }
    }
}