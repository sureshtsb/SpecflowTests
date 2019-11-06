﻿using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class DeleteLanguageSteps
    {
        [Given(@"I have Clicked on language tab under profile tab")]
        public void GivenIHaveClickedOnLanguageTabUnderProfileTab()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on Language tab
            Driver.driver.FindElement(By.XPath("//a[@class='item active']")).Click();
        }

        [When(@"I Click on Delete Symbol")]
        public void WhenIClickOnDeleteSymbol()
        {
            //clickdelete tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[2]/i")).Click();
        }

        [Then(@"i should be able to delete the language details")]
        public void ThenIShouldBeAbleToDeleteTheLanguageDetails()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("delete a language Details");

                Thread.Sleep(1000);
                {
                    int i;
                    for (i = 1; i <= 10; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "Spanish";
                        if (ActualValue.Text != "Telugu")

                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, deleted Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "modifdeleteied");
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