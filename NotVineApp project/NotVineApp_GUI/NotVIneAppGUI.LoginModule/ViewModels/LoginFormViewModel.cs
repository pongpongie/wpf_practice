using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;
using NotVineApp.Common.Settings;

namespace NotVineAppGUI.LoginModule.ViewModels
{
    public class LoginFormViewModel : ViewModelBase
    {
        private string _textBoxText = "Login Form";

        public string TextBoxText
        {
            get => _textBoxText;
            set
            {
                if (_textBoxText != value)
                {
                    _textBoxText = value;
                    OnPropertyChanged();
                }
            }
        }

        public LoginFormViewModel()
        {
            ClickCommand = new RelayCommand(OnButtonClick);
        }

        // Factory Method 추가
        public static LoginFormViewModel Create()
        {
            return new LoginFormViewModel();
        }

        public RelayCommand ClickCommand { get; }

        private void OnButtonClick(object parameter)
        {

            if (ClickCommand != null)
            {
                ModuleManager.DefaultManager.Inject(Regions.MainRegion, PageViews.HomePageView);
                ModuleManager.DefaultManager.Inject(Regions.HomeRegion, Modules.HomeModule);
            }
        }
    }
}