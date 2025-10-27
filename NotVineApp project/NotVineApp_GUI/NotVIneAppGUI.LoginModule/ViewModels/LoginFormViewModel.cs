using NotVineApp.Common.Utils;
using System.Windows;

namespace NotVineAppGUI.LoginModule.ViewModels
{
    internal class LoginFormViewModel : ViewModelBase
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

        public RelayCommand ClickCommand { get; }

        private void OnButtonClick(object parameter)
        {
            TextBoxText = "버튼 클릭으로 텍스트 변경됨";
        }

    }
}
