using System;

namespace nswdblog.automation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://wordpress.com/me");
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
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
            throw new NotImplementedException();
        }
    }
}
