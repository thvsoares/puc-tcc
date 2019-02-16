using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            _driver = new RemoteWebDriver(new Uri("http://selenium:4444/wd/hub"), chromeOptions);
            _driver.Navigate().GoToUrl("http://frontend/curso2.html");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void Navigate()
        {
            var title = _driver.FindElement(By.XPath("/html/body/main/div/h1"));
            Assert.AreEqual("Cursos", title.Text);
        }

        [Test]
        public void UpdateName()
        {
            // Whait possible first load
            Thread.Sleep(5000);

            // Get controls
            var inputName = _driver.FindElement(By.Name("ko_unique_1"));
            var buttonApply = _driver.FindElement(By.Name("ko_unique_2"));
            var text = inputName.GetAttribute("value");
            long test = 0;

            if (text.Contains(" selenium test "))
            {
                test = Convert.ToInt64(text.Substring(22));
                Assert.IsTrue(text.StartsWith("Curso 1") && text.EndsWith(test.ToString()), "Incorrect name input inital state");
            }
            else
            {
                Assert.AreEqual("Curso 1", text, "Incorrect name input inital state");
            }

            Assert.AreEqual(false, buttonApply.Displayed, "Incorrect apply button inital state");

            inputName.Clear();
            inputName.SendKeys($"Curso 1 selenium test {++test}");
            Assert.AreEqual(true, buttonApply.Displayed, "The apply button should be visible after the text update");

            buttonApply.Click();
            // Time for the backend to process
            Thread.Sleep(1000);

            _driver.Navigate().Refresh();
            // Time to update the response
            Thread.Sleep(1000);

            // Refresh control references
            inputName = _driver.FindElement(By.Name("ko_unique_1"));
            buttonApply = _driver.FindElement(By.Name("ko_unique_2"));

            Assert.AreEqual($"Curso 1 selenium test {test}", inputName.GetAttribute("value"), "The backend value should be updated");
            Assert.AreEqual(false, buttonApply.Displayed, "The apply button shuld be on the initial state");
        }
    }
}