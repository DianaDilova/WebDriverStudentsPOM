using OpenQA.Selenium;

namespace WebDriverStudentsPOM.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }
        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/add-student";

        public IWebElement ElementErrorMsg => driver.FindElement(By.CssSelector("body > div"));
        public IWebElement FieldStudentName => driver.FindElement(By.Id("name"));
        public IWebElement FieldStudentEmail => driver.FindElement(By.Id("email"));
        public IWebElement ButtonAdd => driver.FindElement(By.CssSelector("body > form > button"));

        public void AddStudent(string name, string email)
        {
            FieldStudentName.SendKeys(name);
            FieldStudentEmail.SendKeys(email);

            ButtonAdd.Click();
        }
        public string GetErrorMsg()
        {
            return ElementErrorMsg.Text;
        }
    }
}
