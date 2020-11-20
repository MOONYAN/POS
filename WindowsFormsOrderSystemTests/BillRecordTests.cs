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
    public class BillRecordTests
    {
        Meal _meal;
        BillRecord _billRecord;
        PrivateObject _target;
        string _propertyString;
        const string DEFAULT = "default";
        const string TEST = "test";
        Random _random = new Random();

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]
        public void Initialize()
        {
            _meal = new Meal();
            _billRecord = new BillRecord(_meal, 0);
            //_meal = new Meal("",new Category(),0,"","");
            _target = new PrivateObject(_billRecord);
            _propertyString = DEFAULT;
        }

        [TestMethod()]
        public void BillRecordTest()
        {
            Assert.AreEqual("Delete",_billRecord.Delete);
            Assert.AreEqual("", _billRecord.Name);
            Assert.AreEqual("", _billRecord.Category);
            Assert.AreEqual(0, _billRecord.Price);
            Assert.AreEqual(0, _billRecord.Quantity);
            Assert.AreEqual(0, _billRecord.Subtotal);
        }

        [TestMethod()]
        public void HandleMealPropertyChangedTest()
        {
            _meal.Name = "testMeal";
            Assert.AreEqual("testMeal", _billRecord.Name);
            _meal.Category.Name = "testCategory";
            Assert.AreEqual("testCategory", _billRecord.Category);
            int times = _random.Next(0, 10);
            for (int i = 0; i < times; i++)
            {
                int price = _random.Next();
                int quantity = _random.Next();
                _meal.Price = price;
                _billRecord.Quantity = quantity;
                Assert.AreEqual(price, _billRecord.Price);
                Assert.AreEqual(quantity, _billRecord.Quantity);
                Assert.AreEqual(quantity*price,_billRecord.Subtotal);
            }
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
            _billRecord.PropertyChanged += ProvePropertyChanged;
            _target.Invoke("NotifyPropertyChanged", "");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProvePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _propertyString = TEST;
        }
    }
}
