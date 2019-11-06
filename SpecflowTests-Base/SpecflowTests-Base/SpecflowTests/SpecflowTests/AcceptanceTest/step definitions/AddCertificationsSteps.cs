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
    public class AddCertificationsSteps
    {
        [Given(@"I have clicked on Certification tab under profile")]
        public void GivenIHaveClickedOnCertificationTabUnderProfile()
        {
            //clicking on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //clicking on Cerification tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
        }

        [Given(@"I have clicked on add new and given details")]
        public void GivenIHaveClickedOnAddNewAndGivenDetails()
        {
            //click on add new
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")).Click();
            // add certificate or award
            Driver.driver.FindElement(By.XPath("//input[@class='certification-award capitalize']")).SendKeys("ISTQB");
            // add certified from
            Driver.driver.FindElement(By.XPath("//input[@class='received-from capitalize']")).SendKeys("ANZTB");
            // add or select year
            IWebElement addCerification = Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']"));
            SelectElement addcerificationyear = new SelectElement(addCerification);
            addcerificationyear.SelectByText("2018");
            //Console.WriteLine(addCerification.Text);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            //click add
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")).Click();
        }
        
        [Then(@"i should me able to add certification details")]
        public void ThenIShouldMeAbleToAddCertificationDetails()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a certification Details");

                Thread.Sleep(1000);
                {
                    int i;
                    for (i = 1; i <= 10; i++)
                    {
                        //string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                        IWebElement ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody["+i+"]/tr/td[1]"));
                        Thread.Sleep(1000);
                        Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "Spanish";
                        if (ActualValue.Text == "ISTQB")

                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, added Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "added");
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