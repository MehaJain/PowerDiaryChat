using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using PowerDiaryChat.Services.Enums;
using PowerDiaryChat.Services.interfaces;
using PowerDiaryChat.Services.Model;

namespace PowerDiaryChat.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IChatService chatService;
        private GranularityLevel granularityLevel;
        
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IChatService _chatService)
        {
            chatService = _chatService;
            LoadGranularity();
            this.SelectedGranularityLevel = GranularityLevel.Hourly;
        }

        private void LoadGranularity()
        {
            Granularity = Enum.GetValues(typeof(GranularityLevel))
                                            .Cast<GranularityLevel>()
                                            .ToList();

            this.RaisePropertyChanged(() => this.Granularity);
        }

        public List<GranularityLevel> Granularity { get; set; }
        public IEnumerable<IGrouping<DateTime, ChatModelDto>> Chats { get; set; }

        public GranularityLevel SelectedGranularityLevel
        {
            get => this.granularityLevel;
            set
            {
                this.granularityLevel = value;
                LoadChats();
                this.RaisePropertyChanged(() => this.SelectedGranularityLevel);
            }
        }

        private void LoadChats()
        {
            Chats = chatService.GetChats(DateTime.Today, this.SelectedGranularityLevel).GroupBy(obj => obj.Key);
            this.RaisePropertyChanged(() => this.Chats);
        }
    }
}