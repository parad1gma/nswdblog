using nswdblog.automation;
using OpenQA.Selenium;

namespace nswdblog.tests
{
    public class PostPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.ClassName(""));
                if (title != null)
                    return title.Text;
                return string.Empty;
            }
        }
    }
}