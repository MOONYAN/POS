using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.IO;


namespace CodedUITestProject
{
    /// <summary>
    /// CustomerSideFormTests 的摘要描述
    /// </summary>
    [CodedUITest]
    public class CustomerSideFormTests
    {
        private const string FILE_NAME = @"WindowsFormsOrderSystem.exe";

        private enum STARTUP
        {
            StartUpForm,
            CustomerSideFormButton,
            RestaurantSideFormButton,
            ExitButton
        };

        private enum FORM
        {
            StartUpForm,
            CustomerSideForm,
            RestaurantSideForm
        };

        private enum HOST
        {
            LastPage,
            NextPage,
            CostLabel,
            DataGridView
        };

        private enum CATEGORY
        {
            Hambugers,
            Dessert,
            Beverage,
        };

        public CustomerSideFormTests()
        {
        }


        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_NAME, FORM.StartUpForm.ToString());
            Robot.ClickButton(STARTUP.CustomerSideFormButton.ToString());
            Robot.SetForm(FORM.CustomerSideForm.ToString());
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        [TestMethod]
        public void ClickPageButtonTest()
        {
            Robot.ClickButton(HOST.NextPage.ToString());
            Robot.ClickButton(HOST.LastPage.ToString());
        }

        [TestMethod]
        public void ClickMealButtonTest()
        {
            Robot.ClickButton("牛肉麵");
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "1", new string[] { "Delete", "牛肉麵", "Hambugers", "85", "1", "85" });
            Robot.ClickButton("牛肉麵");
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "1", new string[] { "Delete", "牛肉麵", "Hambugers", "85", "2", "170" });
            Robot.AssertText(HOST.CostLabel.ToString(), "Total：170：NTD");
            Robot.AssertDataItemsInDataGridView(HOST.DataGridView.ToString(), 1);
        }

        [TestMethod]
        public void SelectTabControlTest()
        {
            int total = 0;
            Robot.ClickTabControl(CATEGORY.Dessert.ToString());
            Robot.ClickButton("月餅");
            total += 200;
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "1", new string[] { "Delete", "月餅", "Dessert", "200", "1", "200" });
            Robot.ClickTabControl(CATEGORY.Hambugers.ToString());
            Robot.ClickButton("牛肉麵");
            total += 85;
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "2", new string[] { "Delete", "牛肉麵", "Hambugers", "85", "1", "85" });
            Robot.AssertText(HOST.CostLabel.ToString(), string.Format("Total：{0}：NTD", total));
            Robot.AssertDataItemsInDataGridView(HOST.DataGridView.ToString(), 2);
        }
        
        [TestMethod]
        public void ClickNumericUpDownButtonInDataGridViewTest()
        {
            int total = 0;
            Robot.ClickTabControl(CATEGORY.Dessert.ToString());
            Robot.ClickButton("月餅");

            Robot.ClickTabControl(CATEGORY.Hambugers.ToString());
            Robot.ClickButton("牛肉麵");

            Robot.ClickNumericUpDownButtonInDataGridView(HOST.DataGridView.ToString(), 0, 4, Robot.NumericDirect.UP, 3);
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "1", new string[] { "Delete", "月餅", "Dessert", "200", "4", (200 * 4).ToString() });
            
            Robot.ClickNumericUpDownButtonInDataGridView(HOST.DataGridView.ToString(), 1, 4, Robot.NumericDirect.UP, 3);            
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "2", new string[] { "Delete", "牛肉麵", "Hambugers", "85", "4", (85 * 4).ToString() });

            Robot.ClickNumericUpDownButtonInDataGridView(HOST.DataGridView.ToString(), 0, 4, Robot.NumericDirect.DOWN, 1);
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "1", new string[] { "Delete", "月餅", "Dessert", "200", "3", (200 * 3).ToString() });

            total = 200 * 3 + 85 * 4;
            Robot.AssertText(HOST.CostLabel.ToString(), string.Format("Total：{0}：NTD", total));

        }

        [TestMethod]
        public void ClickDataGridViewCellContentTest()
        {
            Robot.ClickButton("牛肉麵");
            Robot.AssertDataItemsInDataGridView(HOST.DataGridView.ToString(),1);
            Robot.ClickDeleteButtonInDataGridView(HOST.DataGridView.ToString(),0,0);
            Robot.AssertDataItemsInDataGridView(HOST.DataGridView.ToString(), 0);
        }

        #region 其他測試屬性

        // 您可以使用下列其他屬性撰寫測試: 

        ////在每項測試執行前先使用 TestInitialize 執行程式碼 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // 若要為這個測試產生程式碼，請在捷徑功能表上選取 [產生自動程式碼 UI 測試的程式碼]，並選取其中一個功能表項目。
        //}

        ////在每項測試執行後使用 TestCleanup 執行程式碼
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // 若要為這個測試產生程式碼，請在捷徑功能表上選取 [產生自動程式碼 UI 測試的程式碼]，並選取其中一個功能表項目。
        //}

        #endregion

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
