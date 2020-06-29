using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using PowerDiaryChat.DB;
using PowerDiaryChat.Services;
using PowerDiaryChat.Services.interfaces;

namespace PowerDiaryChat.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ChatDbContext>(true);
            SimpleIoc.Default.Register<IChatRepo, ChatRepo>();
            SimpleIoc.Default.Register<IChatService, ChatService>();
            SimpleIoc.Default.Register<MainViewModel>();
            var dbContext = SimpleIoc.Default.GetInstance<ChatDbContext>();
            DummyData.Initialize(dbContext);
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<MainViewModel>();
        }
    }
}