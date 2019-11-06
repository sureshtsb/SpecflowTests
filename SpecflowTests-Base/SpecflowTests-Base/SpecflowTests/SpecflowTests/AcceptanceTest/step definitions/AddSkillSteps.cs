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
    public class AddSkillSteps
    {
        [Given(@"I have clicked on skill tab under profile")]
        public void GivenIHaveClickedOnSkillTabUnderProfile()
        {
            //clicking on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //clicking on skill tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }

        [Given(@"I have clicked on add new and entered details")]
        public void GivenIHaveClickedOnAddNewAndEnteredDetails()
        {
            //click on add 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            //add skill
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Guitar");
            //choose skill level
            IWebElement addSkill = Driver.driver.FindElement(By.XPath("//select[@name='level']"));
            SelectElement selectskill = new SelectElement(addSkill);
            selectskill.SelectByText("Expert");
            
        }
        
        [When(@"I click on add")]
        public void WhenIClickOnAdd()
        {
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }
        
        [Then(@"I should be able to add skill details")]
        public void ThenIShouldBeAbleToAddSkillDetails()
        {
            try
            {
                
                        {
                            //Start the Reports
                            CommonMethods.ExtentReports();
                            Thread.Sleep(1000);
                            CommonMethods.test = CommonMethods.extent.StartTest("Add Skill Details");

                            Thread.Sleep(1000);
                            string ExpectedValue = "Guitar";
                            string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                            
                            //Console.WriteLine("ActualValue.Text");
                            Thread.Sleep(1000);
                            if (ExpectedValue == ActualValue)
                            {
                        Console.WriteLine("Success");
                                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a skill Details Successfully");
                                SaveScreenShotClass.SaveScreenshot(Driver.driver, "skilladded");
                            }

                            else
                                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

                        }
                    
                
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }



        }
    }
}
