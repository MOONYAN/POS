using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsOrderSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
namespace WindowsFormsOrderSystem.Tests
{
    [TestClass()]
    public class CustomerViewModelTests
    {
        string _propertyString;
        PrivateObject _target;
        CustomerViewModel _viewModel;
        Model _model;
        Random _rand = new Random();
        const string DEFAULT = "default";
        const string TEST = "test";

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]

        public void Initialize()
        {
            _model = new Model();
            _viewModel = new CustomerViewModel(_model);
            _target = new PrivateObject(_viewModel);
            _propertyString = DEFAULT;
        }

        [TestMethod()]
        public void CustomerViewModelTest()
        {
            Assert.AreEqual("Page：0/0", _viewModel.PageState);
            Assert.AreEqual(1, _target.GetField("_currentPage"));
            Assert.AreEqual(0, _target.GetField("_mealCount"));
            Assert.IsNull(_viewModel.CurrentCategory);
            Assert.IsNotNull(_viewModel.ShowMealList);
            Assert.IsFalse(_viewModel.EnableLastPage);
            Assert.IsFalse(_viewModel.EnableNextPage);
        }

        [TestMethod()]
        public void ChangeLastPageTest()
        {
            _viewModel.ChangeLastPage();
            Assert.AreEqual(0, _target.GetField("_currentPage"));
        }

        [TestMethod()]
        public void ChangeNextPageTest()
        {
            _viewModel.ChangeNextPage();
            Assert.AreEqual(2, _target.GetField("_currentPage"));
        }

        [TestMethod()]
        public void SetCurrentMealList()
        {
            BindingList<Category> categoryList = _model.CategoryList;
            int pickIndex = _rand.Next(0, categoryList.Count - 1);
            Category category = categoryList[pickIndex];
            _viewModel.CurrentCategory = category;
            List<Meal> mealList = _viewModel.ShowMealList;
            Assert.IsTrue(mealList.All(meal => meal.Category == category));
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            _viewModel.PropertyChanged += ProvePropertyChanged;
            _target.Invoke("NotifyPropertyChanged", "");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProvePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void HandleCategoryDeletedEventTest()
        {
            Category category = new Category();
            _model.AddCategory(category);
            _model.DeleteCategory(category);
            Assert.IsFalse(_model.CategoryList.Contains(category));
        }

        [TestMethod()]
        public void HandleMealAddedEventTest()
        {
            _viewModel._showMealListChangedEvent += ProveShowMealListChangedEvent;
            Meal meal = new Meal();
            _model.AddMeal(meal);
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveShowMealListChangedEvent()
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void HandleMealCategoryChangedTest()
        {
            _viewModel._showMealListChangedEvent += ProveShowMealListChangedEvent;
            Meal meal = new Meal();
            _model.AddMeal(meal);
            meal.Category = new Category();
            Assert.AreEqual(TEST, _propertyString);
        }

        [TestMethod()]
        public void HandleMealDeletedEventTest()
        {
            _viewModel._showMealListChangedEvent += ProveShowMealListChangedEvent;
            Meal meal = new Meal();
            _model.AddMeal(meal);
            _model.DeleteMeal(meal);
            Assert.AreEqual(TEST, _propertyString);
        }

        private void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _propertyString = TEST;
        }   
    }
}
