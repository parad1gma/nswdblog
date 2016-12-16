using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace nswdblog.automation
{
    public class PostPage
    {
        public static string Title
        {
            get
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromMinutes(30));
                var title = wait.Until(ExpectedConditions.ElementExists(By.ClassName("entry-title")));

                //var title = Driver.Instance.FindElement(By.ClassName("entry-title"));
                if (title != null)
                    return title.Text;
                return string.Empty;
            }
        }
    }
}