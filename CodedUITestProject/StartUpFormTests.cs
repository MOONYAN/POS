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
using WindowsFormsOrderSystem;
using System.IO;


namespace CodedUITestProject
{
    /// <summary>
    /// StartUpFormTest 的摘要描述
    /// </summary>
    [CodedUITest]
    public class StartUpFormTests
    {
        private const string FILE_NAME = @"WindowsFormsOrderSystem.exe";

        private enum ACCESSIBLE
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


        public StartUpFormTests()
        {           
        }

        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_NAME, FORM.StartUpForm.ToString());
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        [TestMethod]
        public void StartUpFormTest()
        {
            Robot.AssertButtonEnable(ACCESSIBLE.CustomerSideFormButton.ToString(), true);
            Robot.AssertButtonEnable(ACCESSIBLE.RestaurantSideFormButton.ToString(), true);
            Robot.ClickButton(ACCESSIBLE.ExitButton.ToString());
            Robot.AssertWindowExist(ACCESSIBLE.StartUpForm.ToString(), false);
        }

        [TestMethod]
        public void CustomerButtonTest()
        {
            Robot.SetDelayBetweenActions(500);
            Robot.ClickButton(ACCESSIBLE.CustomerSideFormButton.ToString());
            Robot.AssertButtonEnable(ACCESSIBLE.CustomerSideFormButton.ToString(), false);
            Robot.CloseWindow(FORM.CustomerSideForm.ToString());
            Robot.AssertButtonEnable(ACCESSIBLE.CustomerSideFormButton.ToString(), true);
        }

        [TestMethod]
        public void RestaurantButtonTest()
        {
            Robot.SetDelayBetweenActions(500);
            Robot.ClickButton(ACCESSIBLE.RestaurantSideFormButton.ToString());
            Robot.AssertButtonEnable(ACCESSIBLE.RestaurantSideFormButton.ToString(), false);
            Robot.CloseWindow(FORM.RestaurantSideForm.ToString());
            Robot.AssertButtonEnable(ACCESSIBLE.RestaurantSideFormButton.ToString(), true);
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
