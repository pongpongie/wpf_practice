using NotVineApp.Common.Utils;

namespace NotVineAppGUI.DemoModule.ViewModels
{
    public class SelfTestViewModel : ViewModelBase

    {
        public SelfTestViewModel()
        {

        }

        public static SelfTestViewModel Create()
        {
            return new SelfTestViewModel();
        }
    }
}