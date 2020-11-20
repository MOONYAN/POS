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
    public class OrderTests
    {
        Order _order;
        List<Meal> _mealList;
        Random _random = new Random();
        PrivateObject _target;
        string _propertyString;
        const string DEFAULT = "default";
        const string TEST = "test";

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]
        public void Initialize()
        {
            _order = new Order();
            _target = new PrivateObject(_order);
            _propertyString = DEFAULT;
            _mealList = new List<Meal>();
            for (int i = 0; i < 5; i++)
            {
                Meal meal = new Meal();
                meal.Price = i;
                _mealList.Add(meal);
            }
        }

        [TestMethod()]
        public void OrderTest()
        {
            Assert.AreEqual("Total：0：NTD", _order.TotalCost);
        }

        [TestMethod()]
        public void PickMealTest()
        {
            //List<int> pickIndexList = new List<int>();
            int total = 0;
            int pickTimes = _random.Next(0, 50);
            for (int i = 0; i < pickTimes; i++)
            {
                int pickIndex = _random.Next(0, 4);
                _order.PickMeal(_mealList[pickIndex]);
                //pickIndexList.Add(pickIndex);
                total += pickIndex;
            }
            Assert.AreEqual(string.Format("Total：{0}：NTD", total),_order.TotalCost);
            Assert.IsTrue(_order.PickMealList.Count <= 5);
            Assert.AreEqual(_order.PickMealList.Count, _order.BillRecordList.Count);
        }

        [TestMethod()]
        public void RemoveMealTest()
        {
            List<int> pickIndexList = new List<int>();
            _mealList.ForEach(meal => _order.PickMeal(meal));            
            int removeIndex = _random.Next(0, 4);
            _order.RemoveMeal(removeIndex);
            Assert.IsFalse(_order.PickMealList.Contains(_mealList[removeIndex]));
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
            _order.PropertyChanged += ProvePropertyChanged;
            _target.Invoke("NotifyPropertyChanged", "");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProvePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _propertyString = TEST;
        }

        [TestMethod()]
        public void HandleBillPropertyChangedTest()
        {
            List<int> pickIndexList = new List<int>();
            _mealList.ForEach(meal => _order.PickMeal(meal));            
            Assert.AreEqual(string.Format("Total：{0}：NTD", 10), _order.TotalCost);
            _mealList[0].Price = 5;
            Assert.AreEqual(string.Format("Total：{0}：NTD", 15), _order.TotalCost);
        }

        [TestMethod()]
        public void NotifyPickMealListChangedEventTest()
        {
            _target.Invoke("NotifyPickMealListChangedEvent");
            Assert.AreNotEqual(TEST, _propertyString);
        }

        [TestMethod()]
        public void NotifyPickMealListChangedEventTest_1()
        {
            _order._pickMealListChangedEvent += ProvePickMealListChangedEvent;
            _target.Invoke("NotifyPickMealListChangedEvent");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProvePickMealListChangedEvent()
        {
            _propertyString = TEST;
        }


    }
}
