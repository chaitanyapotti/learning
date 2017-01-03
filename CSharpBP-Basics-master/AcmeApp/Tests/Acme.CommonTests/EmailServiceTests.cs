using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Common.Tests
{
    [TestClass()]
    public class EmailServiceTests
    {
        [TestMethod()]
        public void SendMessage_Success()
        {
            // Arrange
            var email = new EmailService();
            var expected = "Message sent: Test Message";

            // Act
            var actual = email.SendMessage("Test Message",
                "This is a test message", "abc@abc.com");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendMessage_Succesxs()
        {
            // Arrange
            OperationResult.MyProperty.Message = "hello";
            var operationResultTest = OperationResult.MyProperty.Message;
            OperationResult.MyProperty.Success = true;

            // Assert
            Assert.AreEqual(operationResultTest, "hello");
        }
    }
}