using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class ModifyLanguageSteps
    {
        [Given(@"I have clicked on language tab under profile section")]
        public void GivenIHaveClickedOnLanguageTabUnderProfileSection()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on Language tab
            Driver.driver.FindElement(By.XPath("//a[@class='item active']")).Click();
            //click on modify symbol
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")).Click();
        }
        
        [Given(@"i have modified language details")]
        public void GivenIHaveModifiedLanguageDetails()
        {
            //clear value in langauge field and enter new language
            IWebElement LanguageModify = Driver.driver.FindElement(By.XPath("//input[@value='Spanish']"));
            LanguageModify.Clear();
            LanguageModify.SendKeys("English");
            //clear level and give new level
            IWebElement levelModify = Driver.driver.FindElement(By.XPath("//select[@name='level']"));
            SelectElement selectlevel = new SelectElement(levelModify);
            selectlevel.SelectByText("Fluent");
            
        }
        
        [When(@"I click on Update button")]
        public void WhenIClickOnUpdateButton()
        {
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }
        
        [Then(@"i should be able to update the language details")]
        public void ThenIShouldBeAbleToUpdateTheLanguageDetails()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Modify Language details");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//input[@value='English']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language details Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDetailsAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }
    }
}
