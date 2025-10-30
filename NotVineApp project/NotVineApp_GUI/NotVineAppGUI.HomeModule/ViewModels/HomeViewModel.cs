using NotVineApp.Common.Utils;

namespace NotVineAppGUI.HomeModule.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {

        }

        public static HomeViewModel Create()
        {
            return new HomeViewModel();
        }
    }
}