using Microsoft.VisualStudio.TestTools.UnitTesting;
using nswdblog.automation;

namespace nswdblog.tests
{
    [TestClass]
    public class nswdblogTest
    {

        [TestInitialize]
        public void StartUp()
        {
            Driver.Initialize();

            LoginPage.GoTo();
            LoginPage.LoginAs("mile.kordic@nswebdevelopment.com").WithPassword("Parad1gma").Login();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
