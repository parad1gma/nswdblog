using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace nswdblog.automation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "me");
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }

        public static void Logout()
        {
            Driver.Instance.FindElement(By.ClassName("me-sidebar__signout-button")).Click();
        }
    }

    public class LoginCommand
    {
        private readonly string username;
        private string password;

        public LoginCommand(string username)
        {
            this.username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");

            var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
            loginInput.Clear();
            loginInput.SendKeys(username);

            var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
            loginButton.Click();
        }
    }
}
