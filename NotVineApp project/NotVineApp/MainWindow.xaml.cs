using NotVineApp.Common.Services;
using NotVineAppGUI.LoginModule.Views;
using NotVineAppGUI.RegionPageView.Views;
using System.Windows;
using System.Windows.Input;

namespace NotVineApp
{
    public partial class MainWindow : Window
    {
        private readonly INavigationService _navigationService;

        public MainWindow(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;

            // 네비게이션 초기화
            _navigationService.Initialize(MainContentControl);

            // 시작 페이지
            _navigationService.NavigateTo<AuthPageView>();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}