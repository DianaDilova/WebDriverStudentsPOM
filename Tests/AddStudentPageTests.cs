using NUnit.Framework;
using WebDriverStudentsPOM.Pages;

namespace WebDriverStudentsPOM.Tests
{
    public class AddStudentPageTests : BaseTest
    {
        private AddStudentPage page;

        [SetUp]
        public void Setup()
        {
            this.page = new AddStudentPage(driver);
        }

        [Test]

        public void Test_TestAddStudentPage_Content()
        {
            page.Open();

            Assert.That(page.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(page.GetPageHeadingText(), Is.EqualTo("Register New Student"));
            Assert.That(page.FieldStudentName.Text, Is.EqualTo(""));
            Assert.That(page.FieldStudentEmail.Text, Is.EqualTo(""));
            Assert.That(page.ButtonAdd.Text, Is.EqualTo("Add"));

        }

        [Test]

        public void Test_TestAddStudentPage_Links()
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

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            page.Open();

            string name = "New student" + DateTime.Now.Ticks;
            string email = "email" + DateTime.Now.Ticks + "@email.com";

            page.AddStudent(name, email);

            var viewStudentPage = new ViewStudentPage(driver);
            Assert.IsTrue(viewStudentPage.IsPageOpen());

            //Assert.Contains(name, viewStudentPage.GetRegisteredStudents());
            var studentsList = viewStudentPage.GetRegisteredStudents();
            Assert.IsTrue(studentsList.Any(s => s.Contains(name)));

            // Assert.That(viewStudentPage.GetRegisteredStudents().Contains(name), Is.True);
        }

        [Test]

        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            page.Open();
            page.AddStudent("", "invalid@email.com");

            Assert.IsTrue(page.IsPageOpen(), "Add Student page should still be open.");

            string errorMsg = page.GetErrorMsg();

            Assert.IsTrue(errorMsg.Contains("Cannot add student"), "Error message should contain 'Cannot add student'.");
        }
    }
}
