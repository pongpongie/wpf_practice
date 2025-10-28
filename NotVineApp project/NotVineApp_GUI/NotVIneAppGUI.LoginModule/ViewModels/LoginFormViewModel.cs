using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;

namespace NotVineAppGUI.LoginModule.ViewModels
{
    public class LoginFormViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
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

        public LoginFormViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ClickCommand = new RelayCommand(OnButtonClick);
        }

        public RelayCommand ClickCommand { get; }

        private void OnButtonClick(object parameter)
        {
            // 문자열 키로 네비게이션 (순환 참조 없음)
            _navigationService.NavigateTo("HomePage");
        }
    }
}