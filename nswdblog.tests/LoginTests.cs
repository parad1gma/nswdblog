using Microsoft.VisualStudio.TestTools.UnitTesting;
using nswdblog.automation;

namespace nswdblog.tests
{
    [TestClass]
    public class LoginTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void AdminUserCanLogin()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("mile.kordic@nswebdevelopment.com").WithPassword("Parad1gma").Login();

            Assert.IsTrue(MyProfilePage.IsAt, "Failed to login.");
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Finalize();
        }
    }
}
