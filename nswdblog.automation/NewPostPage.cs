using System;
using OpenQA.Selenium;

namespace nswdblog.automation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            var menuposts = Driver.Instance.FindElement(By.Id("menu-posts"));
            menuposts.Click();

            var addNew = Driver.Instance.FindElement(By.Id("Add New"));
            addNew.Click();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            throw new NotImplementedException();
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public void Publish()
        {
            throw new NotImplementedException();
        }

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }
    }
}
