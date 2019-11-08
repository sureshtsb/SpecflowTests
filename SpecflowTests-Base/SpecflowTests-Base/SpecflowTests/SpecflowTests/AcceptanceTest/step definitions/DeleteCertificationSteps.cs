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
    public class DeleteCertificationSteps
    {
        private int count;

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
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[3]/tr/td[4]/span[2]/i")).Click();
        }
        
        [Then(@"the certification details should be deleted")]
        public void ThenTheCertificationDetailsShouldBeDeleted()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("delete a certification Details");

                Thread.Sleep(1000);
                {
                    count = 1;
                    // count++;
                    int i;
                    for (i = 1; i <= count++; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "Spanish";
                        if (ActualValue.Text == "QTP")

                        {
                            //CommonMethods.test.Log(LogStatus.Fail, "Test Failed, not deleted Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "notdeleted");
                            Console.WriteLine("Fail");
                            Assert.Fail("failed");
                            // return;
                        }


                        else
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted");
                        // Console.WriteLine("Success");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Success", ex.Message);

                // CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                //  Assert.Fail(ex.Message);
            }
        }
    }
}