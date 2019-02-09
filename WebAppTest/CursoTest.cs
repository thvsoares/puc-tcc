using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _driver.Navigate().GoToUrl("http://localhost/curso.html");
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

            Assert.AreEqual("Curso 1", inputName.GetAttribute("value"), "Incorrect name input inital state");
            Assert.AreEqual(false, buttonApply.Displayed, "Incorrect apply button inital state");

            inputName.SendKeys(" selenium test");
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

            Assert.AreEqual("Curso 1 selenium test", inputName.GetAttribute("value"), "The backend value should be updated");
            Assert.AreEqual(false, buttonApply.Displayed, "The apply button shuld be on the initial state");

            // Reset the text
            inputName.Clear();
            inputName.SendKeys("Curso 1");
            buttonApply.Click();
            // Time to update the response
            Thread.Sleep(1000);
        }
    }
}