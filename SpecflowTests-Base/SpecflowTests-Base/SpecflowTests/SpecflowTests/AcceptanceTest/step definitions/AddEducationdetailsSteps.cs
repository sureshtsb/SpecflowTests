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
    public class AddEducationdetailsSteps
    {
        private int count;

        [Given(@"I have clicked on Education tab")]
        public void GivenIHaveClickedOnEducationTab()
        {
            Thread.Sleep(3000);
            //clicking on profile tab
            //Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //clicking on Education Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
            //click on add new
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();
        }
        
        [Given(@"I have entered Education Deatils")]
        public void GivenIHaveEnteredEducationDeatils()
        {
            Thread.Sleep(1000);
            IWebElement dropDownListuni = Driver.driver.FindElement(By.XPath("//input[@name='instituteName']"));
            dropDownListuni.SendKeys("JNTU");
            //Console.WriteLine(dropDownListuni.Text);

            Thread.Sleep(1000);
            IWebElement dropDownListBox = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
            SelectElement clickThis = new SelectElement(dropDownListBox);
            clickThis.SelectByText("Brazil");
            //Console.WriteLine(dropDownListBox.Text);

            Thread.Sleep(1000);
            IWebElement dropDowntitle = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
            SelectElement click = new SelectElement(dropDowntitle);
            click.SelectByText("B.A");
            //Console.WriteLine(dropDowntitle.Text);

            Thread.Sleep(1000);
            IWebElement bachelor = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
            bachelor.SendKeys("Bachelor Degree");
            //Console.WriteLine(bachelor.Text);

            Thread.Sleep(1000);
            IWebElement dropDowntitle3 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
            SelectElement click2 = new SelectElement(dropDowntitle3);
            click2.SelectByText("2016");
            //Console.WriteLine(dropDowntitle3.Text);
            //clicking add 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();
        }
        
        [Then(@"Education Details should be added\.")]
        public void ThenEducationDetailsShouldBeAdded_()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education Details");

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
                        //string ExpectedValue = "Spanish";
                        if (ActualValue.Text == "Brazil")

                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, added Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "added");
                            Console.WriteLine("Passed");
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
