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
    public class FileReaderTests
    {
        FileReader _fileReader;
        const string CATEGORY_PATH = "../../../CsvSource/Category.csv";
        const string MEAL_PATH = "../../../CsvSource/Meal.csv";

        [TestInitialize]
        [DeploymentItem("WindowsFormsOrderSystem.exe")]
        [DeploymentItem(CATEGORY_PATH)]
        [DeploymentItem(MEAL_PATH)]
        public void Initialize()
        {
            _fileReader = new FileReader();
        }
        [TestMethod()]
        public void GetStringListTest()
        {
            List<string[]> rowList = _fileReader.GetStringList(CATEGORY_PATH);
            string[] category = { "Hambugers", "Dessert", "Beverage", "雜菜" };
            for (int i = 0; i < rowList.Count; i++)
            {
                Assert.AreEqual(category[i],rowList[i][0]);
            }
        }
    }
}
