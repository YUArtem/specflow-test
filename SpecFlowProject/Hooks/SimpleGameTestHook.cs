using SpecFlowProject.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class SimpleGameTestHook
    {
        private static SimpleGameTestDriver gameTestDriver;
        
        [BeforeFeature("SimpleAndroidGameTest")]
        public static void BeforeFeature ()
        {
            gameTestDriver = new SimpleGameTestDriver();
            gameTestDriver.InitializeAppiumDriverAndService();
        }

        [AfterFeature("SimpleAndroidGameTest")]
        public static void AfterFeature ()
        {
            gameTestDriver.Clean();
        }

        [BeforeScenario]
        public static void BeforeScenario ()
        {
            gameTestDriver.OpenApp();
        }
        
        [AfterScenario]
        public static void AfterScenario ()
        {
            gameTestDriver.CloseActiveApp();
        }
    }
}