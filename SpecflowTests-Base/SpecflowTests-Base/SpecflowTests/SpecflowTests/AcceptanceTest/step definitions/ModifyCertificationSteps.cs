using NUnit.Framework;
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
        private int count;

        [Given(@"I have clicked on the Certification Details under the profle section")]
        public void GivenIHaveClickedOnTheCertificationDetailsUnderTheProfleSection()
        {
            //clicking on cerification Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
            //click on modify button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td[4]/span[1]/i")).Click();
        }
        
        [Given(@"I have modified already existing cerification data")]
        public void GivenIHaveModifiedAlreadyExistingCerificationData()
        {
            //clear and enter new data
            IWebElement certificationmodify = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td/div/div/div[1]/input"));
            certificationmodify.Clear();
            certificationmodify.SendKeys("QTP");
            //clear and enter new data for certified from
            //IWebElement certificationmodify2 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[2]/input"));
            //certificationmodify2.Clear();
            //certificationmodify2.SendKeys("Edureka");
        }
        
        [When(@"I Press add button")]
        public void WhenIPressAddButton()
        {
            //click on update
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td/div/span/input[1]")).Click();
        }
        
        [Then(@"the Modified data should be listed in Certification details\.")]
        public void ThenTheModifiedDataShouldBeListedInCertificationDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("modify a certification Details");

                Thread.Sleep(1000);
                {
                    count = 1;
                    count++;
                    int i;
                    for (i = 1; i <= count++; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "sitar";
                        if (ActualValue.Text == "QTP")

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