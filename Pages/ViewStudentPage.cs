using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WebDriverStudentsPOM.Pages
{
    public class ViewStudentPage : BasePage
    {
        public ViewStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/students";
        public ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = this.ListItemsStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }
    }
}
