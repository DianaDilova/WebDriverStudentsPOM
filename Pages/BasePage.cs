using OpenQA.Selenium;

namespace WebDriverStudentsPOM.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual string BaseUrl { get; }
        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.LinkText("View Students"));
        public IWebElement AddStudentLink => driver.FindElement(By.LinkText("Add Student"));
        public IWebElement PageHeadingLabel => driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public bool IsPageOpen()
        {
            return driver.Url == BaseUrl;
        }

        public string GetPageHeadingText()
        {
            return PageHeadingLabel.Text; 
        }

    }
}
