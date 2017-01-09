using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace nswdblog.automation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseAddress
        {
            get { return "https://wordpress.com/"; }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            TurnOnWait();
        }

        public static void Close()
        {
            Instance.Quit();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)timeSpan.TotalSeconds * 1000);
        }


        // Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));
        // ^^^
        // links = row.FindElements(By.LinkText(title));
        // 
        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }

        public enum DriverType
        {
            Firefox,
            Chrome,
            Edge
        }
    }
}