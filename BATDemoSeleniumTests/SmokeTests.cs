using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BATDemoSeleniumTests
{
    [TestFixture]
    public class SmokeTests
    {
        private IWebDriver _driver;

        private static string baseurl = "http://localhost:12142/";

        private static string deleteUsersUrl = "http://localhost:12142/Account/DeleteUsers.cshtml";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Navigate().GoToUrl(deleteUsersUrl);
            _driver.Close();
            _driver.Dispose();
        }

        [Test]
        public void CanGoToAboutPage()
        {
            _driver.Url = baseurl;

            _driver.FindElement(By.LinkText("About")).Click();

            Assert.IsTrue(_driver.Title.Contains("About"));
        }

        [Test]
        public void CanGoToHomePage()
        {
            _driver.Url = baseurl;

            _driver.FindElement(By.LinkText("Home")).Click();

            Assert.IsTrue(_driver.Title.Contains("Home"));
        }

        [Test]
        public void CanGoToContactPage()
        {
            _driver.Url = baseurl;

            _driver.FindElement(By.LinkText("Contact")).Click();

            Assert.IsTrue(_driver.Title.Contains("Contact"));
        }

        [Test]
        public void CanRegisterNewAccount()
        {
            _driver.Url = baseurl;

            _driver.FindElement(By.LinkText("Register")).Click();

            var emailTextBox = _driver.FindElement(By.Id("email"));

            emailTextBox.SendKeys("test@mail.com");

            var passWordTextBox = _driver.FindElement(By.Id("password"));

            passWordTextBox.SendKeys("testpassword");

            var confirmPasswordTextBox = _driver.FindElement(By.Id("confirmPassword"));

            confirmPasswordTextBox.SendKeys("testpassword");

            var submitButton = _driver.FindElement(By.CssSelector("input[type='submit']"));

            submitButton.Click();

            Thread.Sleep(1000);

            Assert.AreEqual(_driver.FindElement(By.CssSelector("#login > a")).Text, "test@mail.com");
        }
    }
}
