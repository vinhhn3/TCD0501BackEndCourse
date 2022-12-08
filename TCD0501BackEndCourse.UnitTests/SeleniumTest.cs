using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TCD0501BackEndCourse.UnitTests
{
    internal class SeleniumTest
    {
        IWebDriver m_driver;

        [Test]
        public void cssDemo()
        {
            // Arrange
            m_driver = new ChromeDriver(
                "\"C:\\Users\\nhuvi\\Projects\\chromedriver_win32\\chromedriver.exe\"");
            m_driver.Url = "http://demo.guru99.com/test/guru99home/";
            m_driver.Manage().Window.Maximize();


            // Store locator values of email text box and sign up button				
            IWebElement emailTextBox = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-email']"));
            IWebElement signUpButton = m_driver.FindElement(By.XPath(".//*[@id='philadelphia-field-submit']"));

            // Act
            emailTextBox.SendKeys("test123@gmail.com");
            signUpButton.Click();

            // Assert
            Assert.IsTrue(true);
        }
    }
}
