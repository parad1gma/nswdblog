using Microsoft.VisualStudio.TestTools.UnitTesting;
using nswdblog.automation;

namespace nswdblog.tests
{
    [TestClass]
    public class CreatePostTests
    {
        [TestInitialize]
        public void StartUp()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void CanCreateBasicPost()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("mile.kordic@nswebdevelopment.com").WithPassword("Parad1gma").Login();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the title").WithBody("Hi, this is the body.").Publish();
            NewPostPage.GoToNewPost();
            Assert.AreEqual(PostPage.Title, "This is the title", "Title did not match new post.");
        }


        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
