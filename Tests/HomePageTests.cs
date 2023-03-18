using NUnit.Framework;
using WebDriverStudentsPOM.Pages;

namespace WebDriverStudentsPOM.Tests
{
    public class HomePageTests : BaseTest
    {
        private HomePage page;

        [SetUp]

        public void Setup()
        {
            this.page = new HomePage(driver);
        }

        [Test]

        public void Test_HomePage_CheckTitle()
        {
            page.Open();

            Assert.That(page.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(page.GetPageHeadingText(), Is.EqualTo("Students Registry"));

            page.GetStudentsCount();
        }

        [Test]

        public void Test_HomePage_Links()
        {
            page.Open();
            page.HomeLink.Click();

            Assert.IsTrue(new HomePage(driver).IsPageOpen());
    
            page.Open();
            page.AddStudentLink.Click();

            Assert.IsTrue(new AddStudentPage(driver).IsPageOpen());

            page.Open();
            page.ViewStudentsLink.Click();

            Assert.IsTrue(new ViewStudentPage(driver).IsPageOpen());
        }
    }
}
