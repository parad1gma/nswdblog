using nswdblog.automation;
using OpenQA.Selenium;

namespace nswdblog.tests
{
    public class MyProfilePage
    {
        public static bool IsAt
        {
            get
            {
                var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                if (h2s.Count > 0)
                    return h2s[0].Text == "nswdblog";
                return false;

            }
        }
    }
}