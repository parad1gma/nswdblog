using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace nswdblog.automation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            var menuposts = Driver.Instance.FindElement(By.CssSelector("a.masterbar__item.masterbar__item-new > span.masterbar__item-content"));
            menuposts.Click();

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("editor-title")));
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            Driver.Instance.FindElement(By.ClassName("notice__action")).Click();

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var winHandle = wait.Until(d =>
            {
                var winHandles = Driver.Instance.WindowHandles;
                if (winHandles.Count > 1)
                    return winHandles[1];
                return null;
            });

            Driver.Instance.Close();

            Driver.Instance.SwitchTo().Window(winHandle);
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public void Publish()
        {
            Driver.Instance.FindElements(By.TagName("textarea"))[0].SendKeys(title);

            Driver.Instance.SwitchTo().Frame("tinymce-1_ifr");

            Driver.Wait(TimeSpan.FromSeconds(1));

            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);

            Driver.Instance.SwitchTo().DefaultContent();

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var publishButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("editor-ground-control__publish-button")));
            publishButton.Click();
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
