using Microsoft.VisualStudio.TestTools.UnitTesting;
using nswdblog.automation;

namespace nswdblog.tests
{
    [TestClass]
    public class CreatePostTests : nswdblogTest
    {
        [TestMethod]
        public void CanCreateBasicPost()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the title").WithBody("Hi, this is the body.").Publish();
            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the title", "Title did not match new post.");
        }
    }
}
