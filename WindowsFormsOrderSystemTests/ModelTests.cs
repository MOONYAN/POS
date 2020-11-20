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
    public class ModelTests
    {
        string _propertyString;
        PrivateObject _target;
        Model _model;
        Random _rand = new Random();
        const string DEFAULT = "default";
        const string TEST = "test";

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]


        public void Initialize()
        {
            _model = new Model();
            _propertyString = DEFAULT;
            _target = new PrivateObject(_model);
            _propertyString = DEFAULT;
        }

        [TestMethod()]
        public void ModelTest()
        {
            Model model = new Model();
            Assert.IsTrue(_model.CategoryList.Count != 0);
            Assert.IsTrue(_model.MealList.Count != 0);
        }

        [TestMethod()]
        public void AddCategoryTest()
        {
            Category category = new Category();
            _model.AddCategory(category);
            Assert.IsTrue(_model.CategoryList.Contains(category));
        }

        [TestMethod()]
        public void AddMealTest()
        {
            Meal meal = new Meal();
            _model.AddMeal(meal);
            Assert.IsTrue(_model.MealList.Contains(meal));
        }

        [TestMethod()]
        public void PickMealTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            int pickIndex = _rand.Next(0, mealList.Count - 1);
            Meal pickMeal = mealList[pickIndex];
            _model.PickMeal(pickMeal);
            Order order = _model.Order;
            Assert.IsTrue(order.PickMealList.Contains(pickMeal));
            BindingList<BillRecord> billList = _model.BillRecordList;
            Assert.IsTrue(billList.ToList().Exists(bill => bill.Name == pickMeal.Name));
        }

        [TestMethod()]
        public void QuitMealTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            mealList.ToList().ForEach(meal => _model.PickMeal(meal));
            int quitIndex = _rand.Next(0, mealList.Count - 1);
            Meal quitMeal = mealList[quitIndex];
            _model.QuitMeal(quitIndex);
            Order order = _model.Order;
            Assert.IsFalse(order.PickMealList.Contains(quitMeal));
        }

        [TestMethod()]
        public void DeleteCategoryTest()
        {
            BindingList<Category> categoryList = _model.CategoryList;
            int deleteIndex = _rand.Next(0, categoryList.Count - 1);
            Category category = categoryList[deleteIndex];
            _model.DeleteCategory(category);
            Assert.IsFalse(_model.CategoryList.Contains(category));
        }

        [TestMethod()]
        public void DeleteMealTest()
        {
            BindingList<Meal> mealList = _model.MealList;
            int deleteIndex = _rand.Next(0, mealList.Count - 1);
            Meal meal = mealList[deleteIndex];
            _model.DeleteMeal(meal);
            Order order = _model.Order;
            Assert.IsFalse(_model.MealList.Contains(meal));
        }

        [TestMethod()]
        public void NotifyMealAddedEventTest()
        {
            _model._mealAddedEvent += ProveMealAddedEvent;
            _model.AddMeal(new Meal());
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveMealAddedEvent(Meal newMeal)
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void NotifyMealDeletedEventTest()
        {
            _model._mealDeletedEvent += ProveMealDeletedEvent;
            Meal meal = new Meal();
            _model.AddMeal(meal);
            Assert.AreEqual(DEFAULT, _propertyString);
            _model.DeleteMeal(meal);
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveMealDeletedEvent(Meal deleteMeal)
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void NotifyCategoryAddEventTest()
        {
            _model._categoryAddEvent += ProveCategoryAddEvent;
            _model.AddCategory(new Category());
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveCategoryAddEvent(Category newCategory)
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void NotifyCategoryDeletedEventTest()
        {
            _model._categoryDeletedEvent += ProveCategoryDeleteEvent;
            Category category = new Category();
            _model.AddCategory(category);
            Assert.AreEqual(DEFAULT, _propertyString);
            _model.DeleteCategory(category);
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveCategoryDeleteEvent(Category deleteCategory)
        {
            _propertyString = TEST;
        }

    }
}
