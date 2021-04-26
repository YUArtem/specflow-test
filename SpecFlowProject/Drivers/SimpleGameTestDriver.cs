using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace SpecFlowProject.Drivers
{
    public class SimpleGameTestDriver
    {
        private const string DEFAULT_DEVICE_NAME                 = "Local Device";
        private const string ANDROID_PLATFORM_NAME               = "Android";
        private const string DEFAULT_AUTOMATION_NAME             = "UIAutomator2";
        private const string DEFAULT_PATH_TO_GAME_FILE           = @"C:\Projects\SpecFlowProject\Resources\test.apk";
        private const string APPIUM_DRIVER_REAL_DEVICE_PARAMETER = "realDevice";

        private AppiumLocalService           appiumLocalService;
        private AppiumDriver<AndroidElement> appiumDriver;

        public void InitializeAppiumDriverAndService ()
        {
            StartAppiumLocalService();
            InitializeAppiumDriver();
        }

        public void CloseActiveApp ()
        {
            appiumDriver.CloseApp();
        }

        public void OpenApp ()
        {
            appiumDriver.LaunchApp();
        }

        public void Clean ()
        {
            appiumDriver.Quit();
            appiumLocalService.Dispose();
        }

        private void StartAppiumLocalService ()
        {
            appiumLocalService = new AppiumServiceBuilder()
                                .UsingAnyFreePort()
                                .Build();

            appiumLocalService.Start();
        }

        private void InitializeAppiumDriver ()
        {
            appiumDriver = new AndroidDriver<AndroidElement>(appiumLocalService, CreateAppiumOptions());
            appiumDriver.CloseApp();
        }

        private AppiumOptions CreateAppiumOptions ()
        {
            AppiumOptions appiumOptions = new();

            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, DEFAULT_DEVICE_NAME);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, ANDROID_PLATFORM_NAME);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, DEFAULT_AUTOMATION_NAME);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, DEFAULT_PATH_TO_GAME_FILE);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            appiumOptions.AddAdditionalCapability(APPIUM_DRIVER_REAL_DEVICE_PARAMETER, true);

            return appiumOptions;
        }
    }
}