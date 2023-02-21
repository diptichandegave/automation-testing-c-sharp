using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using SeleniumExtras.WaitHelpers;

namespace UIAutomationCSharpProject.PageMethods
{
    public class BaseMethods
    {
        readonly string SITEURL = "https://www.bupa.com.au/";
        readonly string INSURANCEURL = "https://www.bupa.com.au/health-insurance";
            
        WebDriver driver = new ChromeDriver();
        String assertDashboardPageText = "for over 75 years";
        String assertInsurancePageText = "8 weeks free";
       
        public void NavigateAndVerifyDashboardPage()
        {
            driver.Navigate().GoToUrl(SITEURL);
            driver.Manage().Window.Maximize();
            IWebElement dashboardPageText = driver.FindElement(By.XPath("//*[@id='main-content']/section[1]/div/div/div[1]/div/div/modular-text[1]/h1"));
            String homeText = dashboardPageText.Text;
            Assert.IsTrue(assertDashboardPageText.Contains(homeText));
        }

        public void navigateToHealthInsuranceTabAndVerify()
        {
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl(INSURANCEURL);
            var assertUrl = driver.Url;
            Assert.IsTrue(assertUrl.Contains("https://www.bupa.com.au/health-insurance"));

            IWebElement insurancePageText = driver.FindElement(By.XPath("//*[@id='main-content']/section[1]/div/div/div[1]/div/div/modular-text[1]/h1"));
            String insuranceText = insurancePageText.Text;
            Assert.IsTrue(assertInsurancePageText.Contains(insuranceText));
            driver.Quit();

            //getShadowDomText();
            //new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable((IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('shared-ui.alert-bar').shadowRoot.querySelector('a[href=\"https://www.bupa.com.au/health-insuranc\"]')"))).Click();
            // driver.FindElement(DashboardLocators.healthInsuranceTab).Click();
        }

        /*public void getShadowDomText()
        {
            var shadowHost = driver.FindElement(By.TagName("shared-ui.alert-bar"));
            var shadowRoot = shadowHost.GetShadowRoot();
            shadowRoot.FindElement(By.CssSelector("header > div.shades-element-9122855443795.shades-static-17341694085377 > div > div > ul > li:nth-child(1) > a")).Click();  
        }*/
    }
}
