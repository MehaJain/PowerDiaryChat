using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerDiaryChat.Services;
using PowerDiaryChat.Services.Enums;
using PowerDiaryChat.Services.interfaces;
using PowerDiaryChat.Tests.Helpers;
using PowerDiaryChat.Tests.Moq;

namespace PowerDiaryChat.Tests.Fixtures
{
    [TestClass]
    public class ChatServiceFixture
    {
        private IChatService chatService;
        private MoqChatRepository chatRepository;

        public ChatServiceFixture()
        {
            chatRepository = new MoqChatRepository();
            chatService = new ChatService(chatRepository);
        }

        [TestMethod]
        public void GivenTodayChatsWhenMinutesGranualityLevelThenAllData()
        {
            var chats = chatService.GetChats(DateTime.Today, GranularityLevel.MinuteByMinute);

            Assert.AreEqual(chats.Count, ChatTestData.GetChats().Count());
        }

        [TestMethod]
        public void GivenTodayChatsWhenHourGranualityLevelThenNotAllData()
        {
            var chats = chatService.GetChats(DateTime.Today, GranularityLevel.Hourly);

            Assert.AreNotEqual(chats.Count, ChatTestData.GetChats().Count());
        }

        [TestMethod]
        public void GivenTodayChatsWhenHalfHourGranualityLevelThenNotAllData()
        {
            var chats = chatService.GetChats(DateTime.Today, GranularityLevel.HalfAnHour);

            Assert.AreNotEqual(chats.Count, ChatTestData.GetChats().Count());
        }

        [TestMethod]
        public void GivenTodayChatsWhenQuarterOfAnHourGranualityLevelThenNotAllData()
        {
            var chats = chatService.GetChats(DateTime.Today, GranularityLevel.QuarterOfAnHour);

            Assert.AreNotEqual(chats.Count, ChatTestData.GetChats().Count());
        }

        [TestMethod]
        public void GivenTodayChatsWhenHourlyGranualityLevelThenValidateData()
        {
            var chats = chatService.GetChats(DateTime.Today, GranularityLevel.Hourly);

            var bobChat = chats.FirstOrDefault();
            Assert.AreEqual("5 people entered", bobChat?.ToString());
        }
    }
}
