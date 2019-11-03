using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class SignUpSteps
    {
        [Given(@"I have given valid data")]
        public void GivenIHaveGivenValidData()
        {
            //click on join
            Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button")).Click();
        }
        
        [Given(@"I have data into the fields")]
        public void GivenIHaveDataIntoTheFields()
        {
            // enter first name
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/input")).SendKeys("Navya");
            //enter last name
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/input")).SendKeys("Venkannagari");
            //enter mail id
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/input")).SendKeys("vnavyareddy456@gmail.com");
            //password
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/input")).SendKeys("SydneyQa2018");
            //confirm password
            Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/input")).SendKeys("SydneyQa2018");
            //click checkbox
            IWebElement checkbox = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/div/input"));
            checkbox.Click();
        }
        
        [When(@"I press join")]
        public void WhenIPressJoin()
        {
            //click on join
            Driver.driver.FindElement(By.XPath("//*[@id='submit-btn']")).Click();
        }
        
        [Then(@"i should be able to signup")]
        public void ThenIShouldBeAbleToSignup()
        {
            Console.WriteLine("Success");
        }
    }
}
