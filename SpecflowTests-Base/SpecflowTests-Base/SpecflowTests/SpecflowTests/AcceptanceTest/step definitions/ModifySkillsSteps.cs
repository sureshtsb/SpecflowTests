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
    public class ModifySkillsSteps
    {
        private int count;

        [Given(@"I have clicked on the skill Details under the profle section")]
        public void GivenIHaveClickedOnTheSkillDetailsUnderTheProfleSection()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on skill tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
            //click on modify symbol
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td[3]/span[1]/i")).Click();
        }

        [Given(@"I have modified already existing skill data")]
        public void GivenIHaveModifiedAlreadyExistingSkillData()
        {
            //clear and reenter data
            IWebElement skillModify = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td/div/div[1]/input"));
            skillModify.Clear();
            skillModify.SendKeys("sitar");
            IWebElement skilllevelModify = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td/div/div[2]/select"));
            SelectElement selectskilllevel = new SelectElement(skilllevelModify);
            selectskilllevel.SelectByText("Beginner");
        }

        [When(@"When I Press add")]
        public void WhenWhenIPressAdd()
        {
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td/div/span/input[1]")).Click();
        }
        
        [Then(@"Then the Modified data should be listed in skills details\.")]
        public void ThenThenTheModifiedDataShouldBeListedInSkillsDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("modify a skills Details");

                Thread.Sleep(1000);
                {
                    count = 1;
                    count++;
                    int i;
                    for (i = 1; i <= count++; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "sitar";
                        if (ActualValue.Text == "sitar")

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