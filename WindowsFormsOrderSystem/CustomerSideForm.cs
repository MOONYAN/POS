using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsOrderSystem
{
    public partial class CustomerSideForm : Form
    {
        private Dictionary<Meal, MealButton> _mealButtons;
        private CustomerViewModel _viewModel;
        private Model _model;

        public CustomerSideForm(Model model)
        {
            _model = model;
            InitializeComponent();
            _mealButtons = new Dictionary<Meal, MealButton>();
            InitializeButtonList();
            _categoryTabControl.TabPages.Clear();
            _model._categoryDeletedEvent += DeleteTabPage;
            _model._categoryAddEvent += AddTabPage;
            _model._mealDeletedEvent += DeleteMealButton;
            _model._mealAddedEvent += AddMealButton;
            _viewModel = new CustomerViewModel(_model);
            _viewModel._showMealListChangedEvent += ShowMealButton;
        }

        //handler show meal button at this page
        private void ShowMealButton()
        {
            List<Meal> showMealList = _viewModel.ShowMealList;
            _mealTableLayoutPanel.Controls.Clear();
            showMealList.ForEach(meal => _mealTableLayoutPanel.Controls.Add(_mealButtons[meal]));
        }

        // handler delete meal
        private void DeleteMealButton(Meal deleteMeal)
        {
            _mealButtons.Remove(deleteMeal);
        }

        //handler add tabPage
        private void AddTabPage(Category newCategory)
        {
            const string PROPERTY_TEXT = "Text";
            const string PROPERTY_NAME = "Name";
            TabPage page = new TabPage();
            page.DataBindings.Add(PROPERTY_TEXT, newCategory, PROPERTY_NAME);
            page.DataBindings.Add(PROPERTY_NAME, newCategory, PROPERTY_NAME);
            page.Tag = newCategory;
            _categoryTabControl.TabPages.Add(page);
            _categoryTabControl.SelectedIndex = -1;
            _categoryTabControl.SelectedIndex = 0;
        }

        //handler delete tabpage
        private void DeleteTabPage(Category deleteCategory)
        {
            BindingList<Meal> mealList = _model.MealList;            
            var query = mealList.Where(meal => meal.Category == deleteCategory);
            query.ToList().ForEach(meal => _mealButtons.Remove(meal));
            _categoryTabControl.TabPages.RemoveByKey(deleteCategory.Name);
        }

        //handler   load form
        private void LoadCustomerSideForm(object sender, EventArgs e)
        {
            const string PROPERTY_TEXT = "Text";
            const string PROPERTY_ENABLE = "Enabled";
            const string PROPERTY_TOTAL_COST = "Order.TotalCost";
            const string PROPERTY_ENABLE_LAST_PAGE = "EnableLastPage";
            const string PROPERTY_ENABLE_NEXT_PAGE = "EnableNextPage";
            const string PROPERTY_PAGE_STATE = "PageState";
            _costLabel.DataBindings.Add(PROPERTY_TEXT, _model, PROPERTY_TOTAL_COST);
            _lastPageButton.DataBindings.Add(PROPERTY_ENABLE, _viewModel, PROPERTY_ENABLE_LAST_PAGE);
            _nextPageButton.DataBindings.Add(PROPERTY_ENABLE, _viewModel, PROPERTY_ENABLE_NEXT_PAGE);
            _pageLabel.DataBindings.Add(PROPERTY_TEXT, _viewModel, PROPERTY_PAGE_STATE);
            _dataGridView.DataSource = _model.BillRecordList;
            _dataGridView.ClearSelection();
            InitializeTabPages();
        }

        // initailize button list
        private void InitializeButtonList()
        {
            BindingList<Meal> mealList = _model.MealList;
            mealList.ToList().ForEach(meal => AddMealButton(meal));
        }

        // add meal button
        private void AddMealButton(Meal newMeal)
        {
            const string PROPERTY_TEXT = "Text";
            const string PROPERTY_NAME = "Name";
            const string PROPERTY_PATH = "Path";
            const string PROPERTY_IMAGE_PATH = "ImagePath";
            MealButton button = new MealButton();
            button.DataBindings.Add(PROPERTY_TEXT, newMeal, PROPERTY_NAME);
            button.DataBindings.Add(PROPERTY_IMAGE_PATH, newMeal, PROPERTY_PATH);
            button.Tag = newMeal;
            button.Click += ClickMealButton;
            button.MouseEnter += EnterMealButton;
            button.MouseLeave += LeaveMealButton;
            _mealButtons.Add(newMeal, button);
        }

        //  initialize tab pages
        private void InitializeTabPages()
        {
            BindingList<Category> categoryList = _model.CategoryList;
            categoryList.ToList().ForEach(category => AddTabPage(category));
        }

        //handler   click meal button
        void ClickMealButton(Object sender, EventArgs e)
        {
            _model.PickMeal((Meal)((MealButton)sender).Tag);
            //_dataGridView.ClearSelection();
        }

        //handler   enter meal button
        void EnterMealButton(object sender, System.EventArgs e)
        {
            _richTextBox.Text = ((Meal)(((MealButton)sender).Tag)).Description;
        }

        //handler   leave meal button
        private void LeaveMealButton(object sender, EventArgs e)
        {
            _richTextBox.Text = null;
        }

        //handler   to last page
        void ClickLastPageButton(Object sender, EventArgs e)
        {
            _viewModel.ChangeLastPage();
        }

        //handler   to next page
        void ClickNextPageButton(Object sender, EventArgs e)
        {
            _viewModel.ChangeNextPage();
        }

        //handler delete select row
        private void ClickDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                _model.QuitMeal(e.RowIndex);
            }
        }

        // handler selecting tab control
        private void SelectTabControl(object sender, TabControlCancelEventArgs e)
        {
            TabPage tabPage = e.TabPage;
            if (tabPage != null)
            {
                tabPage.Controls.Add(_mealTableLayoutPanel);
                _viewModel.CurrentCategory = tabPage.Tag as Category;
            }
            else
            {
                _viewModel.CurrentCategory = null;
            }
        }
    }
}