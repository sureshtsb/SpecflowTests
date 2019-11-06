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
    public class DeleteCertificationSteps
    {
        [Given(@"I have clicked on certification details which is present under the profile")]
        public void GivenIHaveClickedOnCertificationDetailsWhichIsPresentUnderTheProfile()
        {
            //clicking on cerification Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
        }
        
        [When(@"I press delete certication button")]
        public void WhenIPressDeleteCerticationButton()
        {
            //click on delete
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i")).Click();
        }
        
        [Then(@"the certification details should be deleted")]
        public void ThenTheCertificationDetailsShouldBeDeleted()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a certification Details");

                Thread.Sleep(1000);
                string ExpectedValue = "Selenium";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[1]")).Text;
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