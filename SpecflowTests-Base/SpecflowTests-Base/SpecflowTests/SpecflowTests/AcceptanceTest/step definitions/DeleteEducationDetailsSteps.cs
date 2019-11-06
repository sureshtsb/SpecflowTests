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
    public class DeleteEducationDetailsSteps
    {
        

        [Given(@"I have clicked on Education details which is present under the profile")]
        public void GivenIHaveClickedOnEducationDetailsWhichIsPresentUnderTheProfile()
        {
            //click on education details
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
        }
        
        [When(@"I press delete")]
        public void WhenIPressDelete()
        {
            //click on delete
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td[6]/span[2]/i")).Click();
        }
        
        [Then(@"the education details should be deleted")]
        public void ThenTheEducationDetailsShouldBeDeleted()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("delete a education Details");

                Thread.Sleep(1000);
                {
                    int i;
                    for (i = 1; i <= 10; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "Spanish";
                        if (ActualValue.Text != "India")

                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, deleted Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted");
                            Console.WriteLine("Success");
                            return;
                        }


                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        // Console.WriteLine("Failed");

                    }
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}