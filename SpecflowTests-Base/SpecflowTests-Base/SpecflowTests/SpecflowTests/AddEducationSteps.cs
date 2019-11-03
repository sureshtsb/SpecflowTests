using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class AddEducationSteps
    {
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
            Console.WriteLine(dropDownListuni.Text);

            Thread.Sleep(1000);
            IWebElement dropDownListBox = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
            SelectElement clickThis = new SelectElement(dropDownListBox);
            clickThis.SelectByText("India");
            Console.WriteLine(dropDownListBox.Text);

            Thread.Sleep(1000);
            IWebElement dropDowntitle = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
            SelectElement click = new SelectElement(dropDowntitle);
            click.SelectByText("B.A");
            Console.WriteLine(dropDowntitle.Text);

            Thread.Sleep(1000);
            IWebElement bachelor = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
            bachelor.SendKeys("Bachelor Degree");
            Console.WriteLine(bachelor.Text);

            Thread.Sleep(1000);
            IWebElement dropDowntitle3 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
            SelectElement click2 = new SelectElement(dropDowntitle3);
            click2.SelectByText("2016");
            Console.WriteLine(dropDowntitle3.Text);
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
                CommonMethods.test = CommonMethods.extent.StartTest("Add Education Details");

                Thread.Sleep(1000);
                string ExpectedValue = "India";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a education Details Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "educationadded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }



        }
    }
}
