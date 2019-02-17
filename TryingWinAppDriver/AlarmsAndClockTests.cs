using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using TryingWinAppDriver.Sessions;

namespace TryingWinAppDriver
{
    [TestClass]
    public class AlarmsAndClockTests : AlarmsAndClockSession
    {
        private static WindowsElement menuElement;
        private static WindowsElement bottomElement;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Create session to launch a Calculator window
            Initialize(context);
        }


        [TestMethod]
        public void AddNewAlarm()
        {
            session.FindElementByAccessibilityId("AddAlarmButton").Click();

            //var editAlarmHeader = session.FindElementByName("NEW ALARM").Displayed;
            //if (editAlarmHeader)
            //{
                // select the time: hour
                var hourSelector = session.FindElementsByAccessibilityId("HourLoopingSelector");
                //hourSelector.
                ;
                //var selectElement = new SelectElement(hourSelector);
                //selectElement.SelectByValue("2");

                // select the time: minute
                var minuteSelector = session.FindElementByAccessibilityId("MinuteLoopingSelector");
                var minSelectElement = new SelectElement(minuteSelector);
                minSelectElement.SelectByValue("50");

                // select the time: period AM/PM
                var periodSelector = session.FindElementByAccessibilityId("PeriodLoopingSelector");
                var periodSelectElement = new SelectElement(periodSelector);
                periodSelectElement.SelectByValue("PM");
                ;
            //}
        }


        

        [ClassCleanup]
        public static void ClassCleanup()
        {
            CleanUp();
        }
    }
}
