using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace purchaseBot
{
    public class AutomationWeb
    {
        public IWebDriver driver;
        public AutomationWeb()
        {
            
        }
        public void TestAmazonLogin()
        {
            Random rand = new Random(); 
            var driver = new ChromeDriver();
            string url = "https://google.com/";
            string userEmail = "teste@gmail.com";
            string xpathEmailInput = "//*[@id=\"ap_email\"]";
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement googleSearch = wait.Until(i => i.FindElement(By.Name("q")));
            googleSearch.SendKeys("amazon.com");
            googleSearch.SendKeys(OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(rand.Next(1500, 3000));
            IWebElement googleLinks = wait.Until(i => i.FindElement(By.XPath("//*[@id=\"tads\"]/div/div/div/div/div[1]/a/div[1]/span")));
            googleLinks.Click();
            Thread.Sleep(rand.Next(1500, 3000));
            IWebElement signInButton = wait.Until(i => i.FindElement(By.XPath("//span[@id = 'nav-link-accountList-nav-line-1']")));
            signInButton.Click();
            Thread.Sleep(rand.Next(1500, 3000));
            InsertInput(xpathEmailInput, "teste@gmail.com");
            
            //driver.FindElement(By.XPath("//*[@id=\"main\"]/div[5]/div/div[2]/div/div/div/div[2]/div[1]/div/span/a/span")).Click();
            //driver.FindElement(By.XPath("//*[@id=\"my-input\"]")).SendKeys(cep);
            //driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/main/div[2]/div/div[2]/div[2]/div[3]/div/div/div/div[2]/button")).Click();
        }

        public void TestPichau()
        {
            var driver = new ChromeDriver();
            string url = "https://google.com/";
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement googleSearch = wait.Until(i => i.FindElement(By.Name("q")));
            googleSearch.SendKeys("pichau");
            googleSearch.SendKeys(OpenQA.Selenium.Keys.Enter);
            IWebElement linkPichau = wait.Until(i => i.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div/div[1]/div/span/a/h3")));
            linkPichau.Click();
            Random rand = new Random();
            

            //driver.FindElement(By.XPath("//*[@id=\"main\"]/div[5]/div/div[2]/div/div/div/div[2]/div[1]/div/span/a/span")).Click();
            //driver.FindElement(By.XPath("//*[@id=\"my-input\"]")).SendKeys(cep);
            //driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/main/div[2]/div/div[2]/div[2]/div[3]/div/div/div/div[2]/button")).Click();
        }

        private void InsertInput(string XpathInput, string InsertValue)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Random rand = new Random();
            IWebElement Input = wait.Until(i => i.FindElement(By.XPath(XpathInput)));
            for (int x = 0; x < InsertValue.Length; x++)
            {
                Input.SendKeys(InsertValue[x].ToString());
                Thread.Sleep(rand.Next(1500, 3000));
            }
        }


    }
}
