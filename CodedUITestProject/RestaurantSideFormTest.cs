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
    /// RestaurantSideFormTest 的摘要描述
    /// </summary>
    [CodedUITest]
    public class RestaurantSideFormTests
    {
        private const string FILE_NAME = @"WindowsFormsOrderSystem.exe";
        private const string CATEGORY_MANAMER = "Category  Manager";
        private const string MEAL_MANAMER = "Meal Manager";

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

        public RestaurantSideFormTests()
        {
        }

        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_NAME, FORM.StartUpForm.ToString());
            Robot.ClickButton(STARTUP.RestaurantSideFormButton.ToString());
            Robot.SetForm(FORM.RestaurantSideForm.ToString());
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        [TestMethod]
        public void AddCateGoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAMER);
            Robot.ClickButton(CATEGORY.AddNewCategoryButton.ToString());
            Robot.SetEdit(CATEGORY.CategoryNameTextBox.ToString(),"NewCat");
            Robot.ClickButton(CATEGORY.TriggerCategoryButton.ToString());
            Robot.AssertListViewItemByIndex(CATEGORY.CategoryListBox.ToString(), 4, "NewCat");
        }

        [TestMethod]
        public void EditCateGoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAMER);
            Robot.ClickListViewItemByIndex(CATEGORY.CategoryListBox.ToString(),0);            
            Robot.AssertEdit(CATEGORY.CategoryNameTextBox.ToString(), "Hambugers");
            Robot.SetEdit(CATEGORY.CategoryNameTextBox.ToString(), "ModifyCat");
            Robot.ClickButton(CATEGORY.TriggerCategoryButton.ToString());
            Robot.AssertListViewItemByIndex(CATEGORY.CategoryListBox.ToString(), 0, "ModifyCat");
        }

        [TestMethod]
        public void DeleteCateGoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAMER);
            Robot.ClickListViewItemByIndex(CATEGORY.CategoryListBox.ToString(), 0);
            Robot.AssertEdit(CATEGORY.CategoryNameTextBox.ToString(), "Hambugers");
            Robot.ClickButton(CATEGORY.DeleteSelectedCategoryButton.ToString());
            Robot.AssertEdit(CATEGORY.CategoryNameTextBox.ToString(), "");
        }

        [TestMethod]
        public void AddMealTest()
        {
            Robot.ClickTabControl(MEAL_MANAMER);
            Robot.ClickButton(MEAL.AddNewMealButton.ToString());
            Robot.SetEdit(MEAL.MealNameTextBox.ToString(),"NewMeal");
            Robot.SetEdit(MEAL.MealPriceTextBox.ToString(), "999");
            Robot.SetComboBox(MEAL.MealCategoryComboBox.ToString(), "Beverage");
            Robot.ClickButton(MEAL.BrowseButton.ToString());
            Robot.SendKeyEnterToOpenFileDialog();
            Robot.ClickButton(MEAL.TriggerMealButton.ToString());
            Robot.AssertListViewItemByIndex(MEAL.MealListBox.ToString(), 29, "NewMeal");
        }

        [TestMethod]
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

        [TestMethod]
        public void DeleteMealTest()
        {
            Robot.ClickTabControl(MEAL_MANAMER);
            Robot.ClickListViewItemByIndex(MEAL.MealListBox.ToString(), 0);
            Robot.AssertEdit(MEAL.MealNameTextBox.ToString(), "牛肉麵");
            Robot.ClickButton(MEAL.DeleteSelectedMealButton.ToString());
            Robot.AssertEdit(MEAL.MealNameTextBox.ToString(), "");
            Robot.AssertEdit(MEAL.MealPriceTextBox.ToString().ToString(), "0");
            Robot.AssertEdit(MEAL.MealDescriptionTextBox.ToString().ToString(), "");
            Robot.AssertEdit(MEAL.MealPathTextBox.ToString().ToString(), "");
        }

        [TestMethod]
        public void OpenFileDialog()
        {
            Robot.ClickTabControl(MEAL_MANAMER);
            Robot.ClickButton(MEAL.BrowseButton.ToString());
            Robot.SendKeyToOpenFileDialog("Golduck.jpg");
            Robot.SendKeyEnterToOpenFileDialog();
            Robot.SendKeyEnterToOpenFileDialog();
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
