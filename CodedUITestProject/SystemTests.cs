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


namespace CodedUITestProject
{
    /// <summary>
    /// SystemTests 的摘要描述
    /// </summary>
    [CodedUITest]
    public class SystemTests
    {
        private const string FILE_NAME = @"WindowsFormsOrderSystem.exe";
        private const string CATEGORY_MANAMER = "Category  Manager";
        private const string MEAL_MANAMER = "Meal Manager";

        private enum FORM
        {
            StartUpForm,
            CustomerSideForm,
            RestaurantSideForm
        };

        private enum STARTUP
        {
            StartUpForm,
            CustomerSideFormButton,
            RestaurantSideFormButton,
            ExitButton
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
            AddNewCategoryButton,
            DeleteSelectedCategoryButton,
            TriggerCategoryButton,
            CategoryNameTextBox,
            CategoryListBox
        };

        private enum MEAL
        {
            AddNewMealButton,
            DeleteSelectedMealButton,
            TriggerMealButton,
            MealNameTextBox,
            MealPriceTextBox,
            MealCategoryComboBox,
            MealPathTextBox,
            MealDescriptionTextBox,
            BrowseButton,
            MealListBox
        };

        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_NAME, FORM.StartUpForm.ToString());
            Robot.ClickButton(STARTUP.CustomerSideFormButton.ToString());
            Robot.ClickButton(STARTUP.RestaurantSideFormButton.ToString());
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        public SystemTests()
        {
        }

        [TestMethod]
        public void CodedUITestMethod()
        {
            Robot.SetForm(FORM.CustomerSideForm.ToString());
            HostScript();
            Robot.SetForm(FORM.RestaurantSideForm.ToString());
            ServerScript();
            Robot.SetForm(FORM.CustomerSideForm.ToString());
            AssertFinalHost();
        }

        private void AssertFinalHost()
        {
            int total = 0;
            Robot.ClickTabControl("Dessert");
            Robot.ClickButton("月餅");

            Robot.ClickTabControl("Beverage");
            Robot.ClickButton("ModifyMeal");

            Robot.ClickNumericUpDownButtonInDataGridView(HOST.DataGridView.ToString(), 0, 4, Robot.NumericDirect.UP, 3);
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "1", new string[] { "Delete", "月餅", "Dessert", "200", "7", (200 * 7).ToString() });

            Robot.ClickNumericUpDownButtonInDataGridView(HOST.DataGridView.ToString(), 1, 4, Robot.NumericDirect.UP, 3);
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "2", new string[] { "Delete", "ModifyMeal", "Beverage", "999", "8", (999 * 8).ToString() });

            Robot.ClickNumericUpDownButtonInDataGridView(HOST.DataGridView.ToString(), 0, 4, Robot.NumericDirect.DOWN, 1);
            Robot.AssertDataGridViewByIndex(HOST.DataGridView.ToString(), "1", new string[] { "Delete", "月餅", "Dessert", "200", "6", (200 * 6).ToString() });

            total += 200 * 6 + 999 * 8;
            Robot.AssertText(HOST.CostLabel.ToString(), string.Format("Total：{0}：NTD", total));
        }

        private void ServerScript()
        {
            EditMealTest();
            EditCateGoryTest();
            DeleteCateGoryTest();
            DeleteMealTest();
        }

        private void HostScript()
        {
            int total = 0;
            Robot.ClickTabControl("Dessert");
            Robot.ClickButton("月餅");

            Robot.ClickTabControl("Hambugers");
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

        public void EditMealTest()
        {
            Robot.ClickTabControl(MEAL_MANAMER);
            Robot.ClickListViewItemByIndex(MEAL.MealListBox.ToString(), 0);
            Robot.AssertEdit(MEAL.MealNameTextBox.ToString(), "牛肉麵");
            Robot.SetEdit(MEAL.MealNameTextBox.ToString(), "ModifyMeal");
            Robot.SetEdit(MEAL.MealPriceTextBox.ToString(), "999");
            Robot.SetComboBox(MEAL.MealCategoryComboBox.ToString(), "Beverage");
            Robot.ClickButton(MEAL.BrowseButton.ToString());
            Robot.SendKeyEnterToOpenFileDialog();
            Robot.ClickButton(MEAL.TriggerMealButton.ToString());
            Robot.AssertListViewItemByIndex(MEAL.MealListBox.ToString(), 0, "ModifyMeal");
        }

        public void EditCateGoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAMER);
            Robot.ClickListViewItemByIndex(CATEGORY.CategoryListBox.ToString(), 0);
            Robot.AssertEdit(CATEGORY.CategoryNameTextBox.ToString(), "Hambugers");
            Robot.SetEdit(CATEGORY.CategoryNameTextBox.ToString(), "ModifyCat");
            Robot.ClickButton(CATEGORY.TriggerCategoryButton.ToString());
            Robot.AssertListViewItemByIndex(CATEGORY.CategoryListBox.ToString(), 0, "ModifyCat");
        }

        public void DeleteCateGoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAMER);
            Robot.ClickListViewItemByIndex(CATEGORY.CategoryListBox.ToString(), 3);
            Robot.AssertEdit(CATEGORY.CategoryNameTextBox.ToString(), "雜菜");
            Robot.ClickButton(CATEGORY.DeleteSelectedCategoryButton.ToString());
            Robot.AssertEdit(CATEGORY.CategoryNameTextBox.ToString(), "");
        }

        public void DeleteMealTest()
        {
            Robot.ClickTabControl(MEAL_MANAMER);
            Robot.ClickListViewItemByIndex(MEAL.MealListBox.ToString(), 1);
            Robot.AssertEdit(MEAL.MealNameTextBox.ToString(), "雞排");
            Robot.ClickButton(MEAL.DeleteSelectedMealButton.ToString());
            Robot.AssertEdit(MEAL.MealNameTextBox.ToString(), "");
            Robot.AssertEdit(MEAL.MealPriceTextBox.ToString().ToString(), "0");
            Robot.AssertEdit(MEAL.MealDescriptionTextBox.ToString().ToString(), "");
            Robot.AssertEdit(MEAL.MealPathTextBox.ToString().ToString(), "");
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
