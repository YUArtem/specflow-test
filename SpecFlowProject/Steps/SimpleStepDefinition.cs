using System;
using System.Threading;
using Altom.AltUnityDriver;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class SimpleStepDefinition
    {
        private AltUnityDriver altUnityDriver;

        [Given(@"I opened the game")]
        public void GivenIOpenedTheGame ()
        {
            AltUnityPortForwarding.ForwardAndroid();
            altUnityDriver = new AltUnityDriver();
        }

        [Then(@"I should see main menu")]
        public void ThenIShouldSeeMainMenu ()
        {
            Assert.IsTrue(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
        }

        [Then(@"I close the game")]
        public void ThenICloseTheGame ()
        {
            altUnityDriver.Stop();
        }

        [When(@"the player enter to the room")]
        public void WhenThePlayerShouldBeTeleportedToTheRoom ()
        {
            const string expectedResult = "true";

            string test = WaitForValueChanged(altUnityDriver.FindObject(By.NAME, "Room"), expectedResult);

            Assert.AreEqual(test, expectedResult);
        }

        [Given(@"I pressed Space button")]
        public void ThenIPressedSpaceButton ()
        {
            altUnityDriver.PressKeyAndWait(AltUnityKeyCode.Space);
        }

        private string WaitForValueChanged (AltUnityObject valueProvider, string expectedResult)
        {
            string result = GetIsPlayerEnteredRoomValue();

            while (expectedResult != result)
            {
                try
                {
                    result = GetIsPlayerEnteredRoomValue();
                }
                catch (Exception)
                {
                    // ignored
                }

                Thread.Sleep(Convert.ToInt32(1000.0));
            }

            return result;

            string GetIsPlayerEnteredRoomValue ()
            {
                return valueProvider.GetComponentProperty("DefaultNamespace.Room", "IsPlayerEnteredRoom");
            }
        }

        [Given(@"I typed (.*) in the input field")]
        public void GivenITypedAdminInTheInputField (string playerName)
        {
            GetPlayerNameInputField().SetText(playerName);
        }

        [Then(@"I should see (.*) in the input field")]
        public void ThenIShouldSeeAdminInTheInputField (string expectedPlayerName)
        {
            Thread.Sleep(2000);
            Assert.AreEqual(GetPlayerNameInputField().GetText(), expectedPlayerName);
        }

        private AltUnityObject GetPlayerNameInputField ()
        {
            return altUnityDriver.FindObject(By.NAME, "PlayerNameInput");
        }
    }
}