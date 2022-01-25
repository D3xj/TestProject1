using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string baseURL;

        private By afterfirstClick = By.XPath("//span[text()='Прогноз погоды на 5 дней']");

        [TestInitialize]
        public void setuptest()
        {   
            driver = new ChromeDriver();
            baseURL = "https://meteo.paraplan.net/ru/";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.FindElement(By.XPath("//a[@title='Подробный прогноз погоды на 5 дней']")).Click();
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(afterfirstClick);
            driver.FindElement(afterfirstClick);
            driver.FindElement(By.XPath("//a[@title='Аэрологическая диаграмма']"));
        }

        [TestCleanup]
        public void testcleanup()
        {
            driver.Close();
            driver.Quit();
        }
        
        public void WaitForPageToLoad(By element, int timeoutSecs = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSecs)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }
        
    }
}