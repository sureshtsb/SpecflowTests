﻿using NUnit.Framework;
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
    public class ModifyLanguageSteps
    {
        private int count;

        [Given(@"I have clicked on language tab under profile section")]
        public void GivenIHaveClickedOnLanguageTabUnderProfileSection()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on Language tab
            Driver.driver.FindElement(By.XPath("//a[@class='item active']")).Click();
            //click on modify symbol
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[1]/i")).Click();
        }
        
        [Given(@"i have modified language details")]
        public void GivenIHaveModifiedLanguageDetails()
        {
            //clear value in langauge field and enter new language
            IWebElement languageModify = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td/div/div[1]/input"));
            languageModify.Click();
            languageModify.Clear();
            languageModify.SendKeys("Telugu");
            //clear level and give new level
            IWebElement levelModify = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td/div/div[2]/select"));
            SelectElement selectlevel = new SelectElement(levelModify);
           selectlevel.SelectByText("Fluent");
            
        }
        
        [When(@"I click on Update button")]
        public void WhenIClickOnUpdateButton()
        {
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }
        
        [Then(@"i should be able to update the language details")]
        public void ThenIShouldBeAbleToUpdateTheLanguageDetails()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                //Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("modify a language Details");

                //Thread.Sleep(1000);
                {
                    count = 1;
                    count++;
                    int i;
                    for (i = 1; i <= count++; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                       // Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "Spanish";
                        if (ActualValue.Text == "Telugu")

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