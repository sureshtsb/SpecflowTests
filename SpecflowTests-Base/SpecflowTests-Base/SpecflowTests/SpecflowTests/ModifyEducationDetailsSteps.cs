using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class ModifyEducationDetailsSteps
    {
        [Given(@"I have clicked on the Education Details under the profle section")]
        public void GivenIHaveClickedOnTheEducationDetailsUnderTheProfleSection()
        {
            //clicking on Education Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
            //click on modify button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i")).Click();
        }

        [Given(@"I have modified already existing data")]
        public void GivenIHaveModifiedAlreadyExistingData()
        {
            //add college
            IWebElement modify1 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[1]/input"));
            modify1.Clear();
            modify1.SendKeys("CMR");
            //add country
            IWebElement modify2 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select"));
            //modify2.Clear();
            SelectElement clickThis2 = new SelectElement(modify2);
            clickThis2.SelectByText("Poland");
            //add Title
            IWebElement modify3 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select"));
            //modify3.Clear();
            SelectElement clickThis3 = new SelectElement(modify3);
            clickThis3.SelectByText("B.Tech");
            //add degree
            IWebElement modify4 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input"));
            modify4.Clear();
            modify4.SendKeys("btech");
            //add year
            IWebElement modify5 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[3]/select"));
            //modify5.Clear();
            SelectElement clickThis5 = new SelectElement(modify5);
            clickThis5.SelectByText("2016");

        }

        [When(@"I Press add")]
        public void WhenIPressAdd()
        {
            //click update
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]")).Click();

        }

        [Then(@"the Modified data should be listed in education details\.")]
        public void ThenTheModifiedDataShouldBeListedInEducationDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Modify education details");

                Thread.Sleep(1000);
                string ExpectedValue = "Poland";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue != ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a education details Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "educationdetailsadded");
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