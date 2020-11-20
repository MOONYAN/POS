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
    public class RestaurantCategoryViewModelTests
    {
        string _propertyString;
        PrivateObject _target;
        RestaurantCategoryViewModel _viewModel;
        Model _model;
        Random _rand = new Random();
        const string DEFAULT = "default";
        const string TEST = "test";
        private const string EDIT_CATEGORY = "Edit Category";
        private const string ADD_CATEGORY = "Add Category";
        private const string SAVE = "Save";
        private const string ADD = "Add";

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]

        public void Initialize()
        {
            _model = new Model();
            _viewModel = new RestaurantCategoryViewModel(_model);
            _target = new PrivateObject(_viewModel);
            _propertyString = DEFAULT;
        }

        [TestMethod()]
        public void RestaurantCategoryViewModelTest()
        {
            Assert.AreEqual(EDIT_CATEGORY,_viewModel.FrameText);
            Assert.AreEqual(SAVE, _viewModel.TriggerText);
            Assert.IsFalse(_viewModel.EnableDelete);
            Assert.IsFalse(_viewModel.EnableTrigger);
            Assert.IsTrue(_viewModel.EnableAddMeal);
        }

        [TestMethod()]
        public void DeleteCategoryTest()
        {
            BindingList<Category> categoryList = _model.CategoryList;
            int pickIndex = _rand.Next(0, categoryList.Count - 1);
            Category category = categoryList[pickIndex];
            _viewModel.CurrentCategory = category;
            Assert.IsTrue(_viewModel.EnableDelete);
            _viewModel.DeleteCategory();
            Assert.IsFalse(categoryList.Contains(category));
        }

        public void AddNewCategoryTest()
        {
            BindingList<Category> categoryList = _model.CategoryList;
            _viewModel.SetAddMode();
            _viewModel.CopyCategory.Name = TEST;
            _viewModel.TriggerCategoryAddSave();
            Assert.IsTrue(categoryList.ToList().Exists(category => category.Name == TEST));
        }

        public void UpdateCategoryDataTest()
        {
            BindingList<Category> categoryList = _model.CategoryList;
            int pickIndex = _rand.Next(0, categoryList.Count - 1);
            Category category = categoryList[pickIndex];
            _viewModel.CurrentCategory = category;
            Assert.AreEqual(SAVE,_viewModel.TriggerText);
            _viewModel.CopyCategory.Name = TEST;
            Assert.AreNotEqual(category.Name, _viewModel.CopyCategory.Name);
            _viewModel.TriggerCategoryAddSave();
            Assert.AreEqual(category.Name, _viewModel.CopyCategory.Name);
        }

        [TestMethod()]
        public void TriggerCategoryAddSaveTest()
        {
            AddNewCategoryTest();
        }

        [TestMethod()]
        public void TriggerCategoryAddSaveTest_1()
        {
            UpdateCategoryDataTest();
        }

        [TestMethod()]
        public void SetAddModeTest()
        {
            _viewModel.SetAddMode();
            Assert.AreEqual("",_viewModel.CopyCategory.Name);
            Assert.IsFalse(_viewModel.EnableDelete);
            Assert.AreEqual(ADD_CATEGORY, _viewModel.FrameText);
            Assert.AreEqual(ADD, _viewModel.TriggerText);
            Assert.IsFalse(_viewModel.EnableTrigger);
            Assert.IsNull(_target.GetField("_currentCategory"));
        }
        [TestMethod()]
        public void CurrentUsedMealListTest()
        {
            BindingList<Category> categoryList = _model.CategoryList;
            int pickIndex = _rand.Next(0, categoryList.Count-1);
            Category category = categoryList[pickIndex];
            _viewModel.CurrentCategory = category;
            BindingList<Meal> mealList = _viewModel.CurrentUsedMealList;
            Assert.IsTrue(mealList.ToList().TrueForAll(meal => meal.Category == category));
            Assert.AreEqual(category.Name,_viewModel.CopyCategory.Name);
        }

        [TestMethod()]
        public void SetCategoryCopyValueTest()
        {
            _viewModel.CurrentCategory = null;
            Assert.AreEqual(EDIT_CATEGORY, _viewModel.FrameText);
            Assert.AreEqual(SAVE, _viewModel.TriggerText);
            Assert.IsFalse(_viewModel.EnableDelete);
            Assert.IsFalse(_viewModel.EnableTrigger);
            Assert.IsTrue(_viewModel.EnableAddMeal);
            BindingList<Meal> mealList = _viewModel.CurrentUsedMealList;
            Assert.IsTrue(mealList.ToList().Count == 0);
        }

        [TestMethod()]
        public void IdentifyEnabledDeleteTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            int pickIndex = _rand.Next(0, mealList.Count - 1);
            Meal meal = mealList[pickIndex];
            _model.PickMeal(meal);
            _viewModel.CurrentCategory = meal.Category;
            Assert.IsFalse(_viewModel.EnableDelete);
            _viewModel.CurrentCategory = new Category();
            Assert.IsTrue(_viewModel.EnableDelete);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            _target.Invoke("NotifyPropertyChanged", "");
            Assert.AreNotEqual(TEST, _propertyString);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest_1()
        {
            _viewModel.PropertyChanged += ProvePropertyChanged;
            _target.Invoke("NotifyPropertyChanged", "");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProvePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _propertyString = TEST;
        }
    }
}
