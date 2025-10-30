using NotVineApp.Common.Utils;

namespace NotVineAppGUI.HomeModule.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {


        public HomeViewModel()
        {

        }

        // Factory Method 추가
        public static HomeViewModel Create()
        {
            return new HomeViewModel();
        }
    }
}