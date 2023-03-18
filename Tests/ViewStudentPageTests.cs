using NUnit.Framework;
using WebDriverStudentsPOM.Pages;

namespace WebDriverStudentsPOM.Tests
{
    public class ViewStudentPageTests : BaseTest
    {
        private ViewStudentPage page;

        [SetUp]

        public void Setup()
        {
            this.page = new ViewStudentPage(driver);
        }

        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            page.Open();

            Assert.That(page.GetPageTitle, Is.EqualTo("Students"));
            Assert.That(page.GetPageHeadingText, Is.EqualTo("Registered Students"));

            var students = page.GetRegisteredStudents();

            foreach (string st in students)
            {
                Assert.IsTrue(st.IndexOf("(") > 0);
                Assert.IsTrue(st.LastIndexOf(")") == st.Length - 1);

            }
        }
        [Test]
        public void Test_ViewStudentsPage_Links()
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
