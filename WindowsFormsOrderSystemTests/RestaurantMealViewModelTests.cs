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
    public class RestaurantMealViewModelTests
    {
        string _propertyString;
        PrivateObject _target;
        RestaurantMealViewModel _viewModel;
        Model _model;
        Random _rand = new Random();
        const string DEFAULT = "default";
        const string TEST = "test";
        private const string EDIT_MEAL = "Edit Meal";
        private const string ADD_MEAL = "Add Meal";
        private const string SAVE = "Save";
        private const string ADD = "Add";

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]

        public void Initialize()
        {
            _model = new Model();
            _viewModel = new RestaurantMealViewModel(_model);
            _target = new PrivateObject(_viewModel);
            _propertyString = DEFAULT;
        }

        [TestMethod()]
        public void RestaurantMealViewModelTest()
        {
            Assert.AreEqual(EDIT_MEAL,_viewModel.FrameText);
            Assert.AreEqual(SAVE, _viewModel.TriggerText);
            Assert.IsFalse(_viewModel.EnableDelete);
            Assert.IsFalse(_viewModel.EnableTrigger);
        }

        [TestMethod()]
        public void DeleteMealTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            int pickIndex = _rand.Next(0, mealList.Count - 1);
            Meal meal = mealList[pickIndex];
            _viewModel.CurrentMeal = meal;
            Assert.IsTrue(_viewModel.EnableDelete);
            _viewModel.DeleteMeal();
            Assert.IsFalse(mealList.Contains(meal));
        }

        public void AddNewCategoryTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            Category category = new Category(TEST);
            int price = _rand.Next();
            _viewModel.SetAddMode();
            _viewModel.CopyMeal.Name = TEST;
            _viewModel.CopyMeal.Category = category;
            _viewModel.CopyMeal.Price = price;
            _viewModel.CopyMeal.Path = TEST;
            _viewModel.CopyMeal.Description = TEST;
            _viewModel.TriggerMealAddSave();
            Assert.IsTrue(mealList.ToList().Exists(meal => meal.Name == TEST));
            Assert.IsTrue(mealList.ToList().Exists(meal => meal.Category == category));
            Assert.IsTrue(mealList.ToList().Exists(meal => meal.Price == price));
            Assert.IsTrue(mealList.ToList().Exists(meal => meal.Path == TEST));
            Assert.IsTrue(mealList.ToList().Exists(meal => meal.Description == TEST));
        }

        public void UpdateMealDataTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            Category category = new Category(TEST);
            int price = _rand.Next();
            int pickIndex = _rand.Next(0, mealList.Count - 1);
            Meal meal = mealList[pickIndex];
            _viewModel.CurrentMeal = meal;
            Assert.AreEqual(SAVE, _viewModel.TriggerText);
            _viewModel.CopyMeal.Name = TEST;
            _viewModel.CopyMeal.Category = category;
            _viewModel.CopyMeal.Price = price;
            _viewModel.CopyMeal.Path = TEST;
            _viewModel.CopyMeal.Description = TEST;
            Assert.AreNotEqual(meal.Name, _viewModel.CopyMeal.Name);
            Assert.AreNotEqual(meal.Category, _viewModel.CopyMeal.Category);
            Assert.AreNotEqual(meal.Price, _viewModel.CopyMeal.Price);
            Assert.AreNotEqual(meal.Path, _viewModel.CopyMeal.Path);
            Assert.AreNotEqual(meal.Description, _viewModel.CopyMeal.Description);
            _viewModel.TriggerMealAddSave();
            Assert.AreEqual(meal.Name, _viewModel.CopyMeal.Name);
            Assert.AreEqual(meal.Category, _viewModel.CopyMeal.Category);
            Assert.AreEqual(meal.Price, _viewModel.CopyMeal.Price);
            Assert.AreEqual(meal.Path, _viewModel.CopyMeal.Path);
            Assert.AreEqual(meal.Description, _viewModel.CopyMeal.Description);
        }

        [TestMethod()]
        public void TriggerMealAddSaveTest()
        {
            AddNewCategoryTest();            
        }

        [TestMethod()]
        public void TriggerMealAddSaveTest_1()
        {
            UpdateMealDataTest();
        }

        [TestMethod()]
        public void SetAddModeTest()
        {
            _viewModel.SetAddMode();
            Assert.AreEqual("", _viewModel.CopyMeal.Name);
            Assert.IsFalse(_viewModel.EnableDelete);
            Assert.AreEqual(ADD_MEAL, _viewModel.FrameText);
            Assert.AreEqual(ADD, _viewModel.TriggerText);
            Assert.IsFalse(_viewModel.EnableTrigger);
            Assert.IsNull(_target.GetField("_currentMeal"));
        }

        [TestMethod()]
        public void SetMealCopyValueTest()
        {
            _viewModel.CurrentMeal = null;
            Assert.AreEqual(EDIT_MEAL, _viewModel.FrameText);
            Assert.AreEqual(SAVE, _viewModel.TriggerText);
            Assert.IsFalse(_viewModel.EnableDelete);
            Assert.IsFalse(_viewModel.EnableTrigger);
        }

        [TestMethod()]
        public void IdentifyEnabledDeleteTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            int pickIndex = _rand.Next(0, mealList.Count - 1);
            Meal meal = mealList[pickIndex];
            _model.PickMeal(meal);
            _viewModel.CurrentMeal = meal;
            Assert.IsFalse(_viewModel.EnableDelete);
            _model.QuitMeal(0);
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
