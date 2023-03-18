using OpenQA.Selenium;

namespace WebDriverStudentsPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/";
        public IWebElement ElementStudentsCount => driver.FindElement(By.CssSelector("body > p > b"));

        public int GetStudentsCount()
        {
            var countText = ElementStudentsCount.Text;
            int count = int.Parse(countText);
            return count;
        }
    }
}
