using NUnit.Framework;
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
    public class ModifyEducationDetailsSteps
    {
        private int count;

        [Given(@"I have clicked on the Education Details under the profle section")]
        public void GivenIHaveClickedOnTheEducationDetailsUnderTheProfleSection()
        {
            //clicking on Education Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
            //click on modify button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td[6]/span[1]/i")).Click();
        }
        
        [Given(@"I have modified already existing data")]
        public void GivenIHaveModifiedAlreadyExistingData()
        {
            //add college
           // IWebElement modify1 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[1]/input"));
            //modify1.Clear();
            //modify1.SendKeys("CMR");
            //add country
            IWebElement modify2 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td/div[1]/div[2]/select"));
            //modify2.Clear();
            SelectElement clickThis2 = new SelectElement(modify2);
            clickThis2.SelectByText("India");
            //add Title
            //IWebElement modify3 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select"));
            //modify3.Clear();
            //SelectElement clickThis3 = new SelectElement(modify3);
            //clickThis3.SelectByText("B.Tech");
            //add degree
           // IWebElement modify4 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input"));
           // modify4.Clear();
           // modify4.SendKeys("btech");
            //add year
            //IWebElement modify5 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[3]/select"));
            //modify5.Clear();
            //SelectElement clickThis5 = new SelectElement(modify5);
            //clickThis5.SelectByText("2016");
        }
        
        [When(@"I Press add")]
        public void WhenIPressAdd()
        {
            //click update
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td/div[3]/input[1]")).Click();
        }
        
        [Then(@"the Modified data should be listed in education details\.")]
        public void ThenTheModifiedDataShouldBeListedInEducationDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("modify a education Details");

                Thread.Sleep(1000);
                {
                    count = 1;
                    count++;
                    int i;
                    for (i = 1; i <= count++; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "sitar";
                        if (ActualValue.Text == "India")

                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, modified Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "modified");
                            Console.WriteLine("Success");
                            return;
                        }


                        else

                            Console.WriteLine("Failed");

                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail(ex.Message);
            }
        }
    }
}