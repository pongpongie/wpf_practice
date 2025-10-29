using System.Windows;
using NotVineApp.Common.Services;
using NotVineAppGUI.LoginModule.Views;
using NotVineAppGUI.LoginModule.ViewModels;
using NotVineAppGUI.RegionPageView.Views;
using NotVineAppGUI.RegionPageView.ViewModels;
using NotVineAppGUI.HomeModule.Views;
using NotVineAppGUI.HomeModule.ViewModels;
using NotVineAppGUI.NavModule.ViewModels;
using NotVineAppGUI.NavModule.Views;

namespace NotVineApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 서비스 등록
            ConfigureServices();

            // MainWindow 생성 및 표시
            var mainWindow = ServiceLocator.Instance.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices()
        {
            var locator = ServiceLocator.Instance;

            // Services - Singleton
            var navigationService = new NavigationService();
            locator.RegisterSingleton<INavigationService>(navigationService);

            // 뷰 키 등록 (순환 참조 방지)
            //navigationService.RegisterView<LoginFormView>("LoginForm");
            //navigationService.RegisterView<HomeView>("Home");
            //navigationService.RegisterView<NavView>("Nav");
            navigationService.RegisterView<HomePageView>("HomePage");
            navigationService.RegisterView<AuthPageView>("AuthPage");

            // ViewModels - Transient
            locator.RegisterTransient(() =>
                new LoginFormViewModel(locator.Resolve<INavigationService>()));
            locator.RegisterTransient(() => new HomeViewModel(locator.Resolve<INavigationService>()));
            locator.RegisterTransient(() => new NavViewModel(locator.Resolve<INavigationService>()));

            locator.RegisterTransient(() => new AuthPageViewModel());
            locator.RegisterTransient(() => new HomePageViewModel());

            // Views - Transient
            locator.RegisterTransient(() =>
                new LoginFormView(locator.Resolve<LoginFormViewModel>()));
            locator.RegisterTransient(() => new HomeView(locator.Resolve<HomeViewModel>()));
            locator.RegisterTransient(() => new NavView(locator.Resolve<NavViewModel>()));

            locator.RegisterTransient(() => new HomePageView());
            locator.RegisterTransient(() => new AuthPageView());

            // MainWindow - Singleton
            locator.RegisterSingleton(() =>
                new MainWindow(locator.Resolve<INavigationService>()));
        }
    }
}