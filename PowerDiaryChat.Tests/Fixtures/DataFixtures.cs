using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerDiaryChat.Tests.Helpers;

namespace PowerDiaryChat.Tests.Fixtures
{
    [TestClass]
    public class DataFixtures
    {
        [TestMethod]
        public void GivenCommentChatValidateToStringValue()
        {
            var chat = TestHelper.CreatCommentChat(1, "Bob", "Hi there!");

            Assert.AreEqual(chat.ToString(), "Bob comments: \"" + "Hi there!" + "\"");
        }

        [TestMethod]
        public void GivenHighFiveChatValidateToStringValue()
        {
            var chat = TestHelper.CreatHighFiveChat(1, "Bob", "Kate");

            Assert.AreEqual(chat.ToString(), "Bob high-fives Kate");
        }

        [TestMethod]
        public void GivenUserEntersChatValidateToStringValue()
        {
            var chat = TestHelper.CreatUserEntersChat(1, "Bob");

            Assert.AreEqual(chat.ToString(), "Bob enters the room");
        }

        [TestMethod]
        public void GivenUserLeavesChatValidateToStringValue()
        {
            var chat = TestHelper.CreatUserLeavesChat(1, "Bob");

            Assert.AreEqual(chat.ToString(), "Bob leaves");
        }
    }
}