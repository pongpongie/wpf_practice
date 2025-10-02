using NUnit.Framework;
using Practice; // MyViewModel 네임스페이스

namespace PracticeTests
{
    [TestFixture]
    public class MyViewModelTests
    {
        [Test]
        public void Message_PropertyChanged_Event_Fires()
        {
            // Arrange
            var vm = new MyViewModel();
            bool eventFired = false;
            vm.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Message")
                    eventFired = true;
            };

            // Act
            vm.Message = "Test";

            // Assert
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void ButtonClickCommand_Executes_And_Changes_Message()
        {
            // Arrange
            var vm = new MyViewModel();

            // Act
            vm.ButtonClickCommand.Execute(null);

            // Assert
            Assert.AreEqual("Button was clicked!", vm.Message);
        }
    }
}
