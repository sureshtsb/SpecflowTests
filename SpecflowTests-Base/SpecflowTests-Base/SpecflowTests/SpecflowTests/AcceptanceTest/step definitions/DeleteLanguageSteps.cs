using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class DeleteLanguageSteps
    {
        [Given(@"I have Clicked on language tab under profile tab")]
        public void GivenIHaveClickedOnLanguageTabUnderProfileTab()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on Language tab
            Driver.driver.FindElement(By.XPath("//a[@class='item active']")).Click();
        }

        [When(@"I Click on Delete Symbol")]
        public void WhenIClickOnDeleteSymbol()
        {
            //clickdelete tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[2]/i")).Click();
        }

        [Then(@"i should be able to delete the language details")]
        public void ThenIShouldBeAbleToDeleteTheLanguageDetails()
        {
            try
            {

                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language Details");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
               // Console.WriteLine("ActualValue.Text");
                Thread.Sleep(500);
                if (ExpectedValue != ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, deleted Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted");
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
