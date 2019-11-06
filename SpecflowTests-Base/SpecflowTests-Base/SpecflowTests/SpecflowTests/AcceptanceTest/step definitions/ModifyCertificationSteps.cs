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
    public class ModifyCertificationSteps
    {
        [Given(@"I have clicked on the Certification Details under the profle section")]
        public void GivenIHaveClickedOnTheCertificationDetailsUnderTheProfleSection()
        {
            //clicking on cerification Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
            //click on modify button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i")).Click();
        }
        
        [Given(@"I have modified already existing cerification data")]
        public void GivenIHaveModifiedAlreadyExistingCerificationData()
        {
            //clear and enter new data
            IWebElement certificationmodify = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[1]/input"));
            certificationmodify.Clear();
            certificationmodify.SendKeys("Selenium");
            //clear and enter new data for certified from
            IWebElement certificationmodify2 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[2]/input"));
            certificationmodify2.Clear();
            certificationmodify2.SendKeys("Edureka");
        }
        
        [When(@"I Press add button")]
        public void WhenIPressAddButton()
        {
            //click on update
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();
        }
        
        [Then(@"the Modified data should be listed in Certification details\.")]
        public void ThenTheModifiedDataShouldBeListedInCertificationDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("modify a Cerification");

                Thread.Sleep(1000);
                string ExpectedValue = "Selenium";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, modified a cerification Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certicationmodified");
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