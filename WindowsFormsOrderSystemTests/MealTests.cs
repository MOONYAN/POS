using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsOrderSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WindowsFormsOrderSystem.Tests
{
    [TestClass()]
    public class MealTests
    {
        Meal _meal;
        PrivateObject _target;
        string _propertyString;
        const string DEFAULT = "default";
        const string TEST = "test";
        //string CATEGORY_NAME = "testCategoryName";
        const string NAME = "testName";
        const int PRICE = 100;
        Category CATEGORY = new Category("testCategory");
        const string PATH = "../testPath/";
        const string DESCRIPTION = "testDescription";

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]
        public void Initialize()
        {
            _meal = new Meal();
            //_meal = new Meal("",new Category(),0,"","");
            _target = new PrivateObject(_meal);
            _propertyString = DEFAULT;
        }

        [TestMethod()]
        public void MealTest()
        {
            Assert.AreEqual("", _meal.Name);
            Assert.IsNotNull(_meal.Category);
            Assert.AreEqual(0, _meal.Price);            
            Assert.AreEqual("", _meal.Path);
            Assert.AreEqual("", _meal.Description);
        }

        [TestMethod()]
        public void MealTest1()
        {
            Meal meal = new Meal(NAME, CATEGORY, PRICE, PATH, DESCRIPTION);
            Assert.AreEqual(NAME, meal.Name);
            Assert.AreEqual(CATEGORY, meal.Category);
            Assert.AreEqual(PRICE, meal.Price);            
            Assert.AreEqual(PATH, meal.Path);
            Assert.AreEqual(DESCRIPTION, meal.Description);
        }

        [TestMethod()]
        public void SetDefaultTest()
        {
            _meal.Name = NAME;
            _meal.Price = PRICE;
            _meal.Category = CATEGORY;
            _meal.Path = PATH;
            _meal.Description = DESCRIPTION;
            Assert.AreEqual(NAME, _meal.Name);
            Assert.AreEqual(CATEGORY, _meal.Category);
            Assert.AreEqual(PRICE, _meal.Price);
            Assert.AreEqual(PATH, _meal.Path);
            Assert.AreEqual(DESCRIPTION, _meal.Description);
            _meal.SetDefault();
            Assert.AreEqual("", _meal.Name);
            Assert.AreEqual("",_meal.Category.Name);
            Assert.AreNotEqual(CATEGORY, _meal.Category);
            Assert.IsNotNull(_meal.Category);
            Assert.AreEqual(0, _meal.Price);
            Assert.AreEqual("", _meal.Path);
            Assert.AreEqual("", _meal.Description);
        }

        [TestMethod()]
        public void CopyValueTest()
        {
            _meal.PropertyChanged += ProvePropertyChanged;
            Meal copyMeal = new Meal(NAME, CATEGORY, PRICE, PATH, DESCRIPTION);
            _meal.CopyValue(copyMeal);
            Assert.AreEqual(NAME, _meal.Name);
            Assert.AreEqual(CATEGORY, _meal.Category);
            Assert.AreEqual(PRICE, _meal.Price);
            Assert.AreEqual(PATH, _meal.Path);
            Assert.AreEqual(DESCRIPTION, _meal.Description);
            copyMeal.SetDefault();
            Assert.AreEqual(NAME, _meal.Name);
            Assert.AreEqual(CATEGORY, _meal.Category);
            Assert.AreEqual(PRICE, _meal.Price);
            Assert.AreEqual(PATH, _meal.Path);
            Assert.AreEqual(DESCRIPTION, _meal.Description);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            _target.Invoke("NotifyPropertyChanged", "");
            Assert.AreEqual(DEFAULT, _propertyString);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest_1()
        {
            _meal.PropertyChanged += ProvePropertyChanged;
            _target.Invoke("NotifyPropertyChanged", "");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProvePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void NotifyCategoryChangedEventTest()
        {
            _target.Invoke("NotifyCategoryChangedEvent");
            Assert.AreEqual(DEFAULT, _propertyString);
        }

        [TestMethod()]
        public void NotifyCategoryChangedEventTest_1()
        {
            _meal._categoryChangedEvent += ProveCategoryChanged;
            _target.Invoke("NotifyCategoryChangedEvent");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveCategoryChanged()
        {
            _propertyString = TEST;
        }

         [TestMethod()]
        public void NotifyValidChangedEventTest()
        {
            _target.Invoke("NotifyValidChangedEvent");
            Assert.AreEqual(DEFAULT, _propertyString);
        }

        [TestMethod()]
        public void NotifyValidChangedEventTest_1()
        {
            _meal._validChangedEvent += ProveValidChanged;
            _target.Invoke("NotifyValidChangedEvent");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveValidChanged()
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void HandleCategoryPropertyChangedTest()
        {
            _meal.PropertyChanged += ProvePropertyChanged;
            _meal.Category.Name = TEST;
            Assert.AreEqual(TEST, _propertyString);
        }

        [TestMethod()]
        public void IdentifyValidTest()
        {
            Assert.IsFalse(_meal.IsValid);
            _meal.Name = NAME;
            Assert.IsFalse(_meal.IsValid);            
            _meal.Price = PRICE;
            Assert.IsFalse(_meal.IsValid);
            _meal.Path = PATH;
            Assert.IsTrue(_meal.IsValid);
            _meal.Category = null;
            Assert.IsFalse(_meal.IsValid);
        }
    }
}
