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
    public class CategoryTests
    {
        string _propertyString;
        PrivateObject _target;
        Category _category;
        const string DEFAULT = "default";
        const string TEST = "test";

        [TestInitialize()]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]
        public void Initialize()
        {
            _category = new Category();
            _target = new PrivateObject(_category);
            _propertyString = DEFAULT;
        }

        [TestMethod()]
        public void CategoryTest()
        {
            Assert.AreEqual("", _category.Name);
            Category category = new Category(TEST);
            Assert.AreEqual(TEST, category.Name);
        }

        [TestMethod()]
        public void SetDefaultTest()
        {
            _category.Name = TEST;
            Assert.AreEqual(TEST, _category.Name);
            _category.SetDefault();
            Assert.AreEqual("", _category.Name);
        }

        [TestMethod()]
        public void CopyValueTest()
        {
            Category copyCategory = new Category(TEST);
            _category.CopyValue(copyCategory);
            Assert.AreEqual(TEST, _category.Name);
            copyCategory.SetDefault();
            Assert.AreEqual(TEST, _category.Name);
        }

        [TestMethod()]
        public void IdentifyValidTest()
        {
            Assert.IsFalse(_category.IsValid);
            _target.Invoke("IdentifyValid");
            Assert.IsFalse(_category.IsValid);
            _target.SetField("_name",TEST);
            _target.Invoke("IdentifyValid");
            Assert.IsTrue(_category.IsValid);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            _target.Invoke("NotifyPropertyChanged","");
            Assert.AreNotEqual(TEST, _propertyString);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest_1()
        {
            _category.PropertyChanged += ProvePropertyChanged;
            _target.Invoke("NotifyPropertyChanged","");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProvePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
            _category._validChangedEvent += ProveValidChanged;
            _target.Invoke("NotifyValidChangedEvent");
            Assert.AreEqual(TEST, _propertyString);
        }

        private void ProveValidChanged()
        {
            _propertyString = TEST;
        }
    }
}
