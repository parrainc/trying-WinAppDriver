using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;

namespace TryingWinAppDriver.Sessions
{
    public class AlarmsAndClockSession
    {
        private const string WinAppDriverServerUrl = "http://127.0.0.1:4723";

        // windows app has an app id, which is the PackageFamilyName+'!App'
        private const string appId = "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App";

        // we just need this field to be accessed through inheritance
        protected static WindowsDriver<WindowsElement> session;

        public static void Initialize(TestContext testContext)
        {
            if (session is null)
            {
                var appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", appId);
                appCapabilities.SetCapability("deviceName", "WindowsPC");

                // start the session/app
                session = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverServerUrl), appCapabilities);
                Debug.Assert(session != null); // if the session could not be initialized, we can not continue...

                // setting the timeout
                session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            }
        }

        public static void CleanUp()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }
    }
}
