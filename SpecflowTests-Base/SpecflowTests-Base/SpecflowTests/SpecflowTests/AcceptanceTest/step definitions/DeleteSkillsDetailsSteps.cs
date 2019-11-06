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
    public class DeleteSkillsDetailsSteps
    {
        [Given(@"I have clicked on skills details which is present under the profile")]
        public void GivenIHaveClickedOnSkillsDetailsWhichIsPresentUnderTheProfile()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on skill tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }

        [When(@"I click on delete")]
        public void WhenIClickOnDelete()
        {
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td[3]/span[2]/i")).Click();
        }

        [Then(@"the skill details should be deleted")]
        public void ThenTheSkillDetailsShouldBeDeleted()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("delete a skill Details");

                Thread.Sleep(1000);
                {
                    int i;
                    for (i = 1; i <= 10; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "Spanish";
                        if (ActualValue.Text != "sitar")

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