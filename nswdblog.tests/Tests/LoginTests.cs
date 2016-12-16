using Microsoft.VisualStudio.TestTools.UnitTesting;
using nswdblog.automation;

namespace nswdblog.tests
{
    [TestClass]
    public class LoginTests : nswdblogTest
    {
        [TestMethod]
        public void AdminUserCanLogin()
        {
            Assert.IsTrue(MyProfilePage.IsAt, "Failed to login.");
        }
    }
}
