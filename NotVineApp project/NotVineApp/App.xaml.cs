using NotVineApp.Common.Utils;
using NotVineApp.Common.Settings;
using NotVineAppGUI.HomeModule.ViewModels;
using NotVineAppGUI.HomeModule.Views;
using NotVineAppGUI.LoginModule.ViewModels;
using NotVineAppGUI.LoginModule.Views;
using NotVineAppGUI.NavModule.ViewModels;
using NotVineAppGUI.NavModule.Views;
using NotVineAppGUI.RegionPageView.ViewModels;
using NotVineAppGUI.RegionPageView.Views;
using System.Windows;

namespace NotVineApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureServices();
            RegisterModules();

            // MainWindow 표시
            var mainWindow = IoCContainer.Instance.Resolve<MainWindow>();
            mainWindow.Show();

            // MainWindow가 표시된 후 모듈 주입
            InjectModules();
        }

        protected ModuleManager Manager => ModuleManager.DefaultManager;

        private void ConfigureServices()
        {
            var container = IoCContainer.Instance;

            // MainWindow를 지연 초기화 싱글톤으로 등록
            container.RegisterSingletonLazy<MainWindow>(() => new MainWindow());

            container.RegisterTransient<LoginFormViewModel>();
            container.RegisterTransient<HomeViewModel>();
            container.RegisterTransient<NavViewModel>();
            container.RegisterTransient<AuthPageViewModel>();
            container.RegisterTransient<HomePageViewModel>();

            // 뷰들은 트랜지언트로 등록 (ModuleManager가 필요할 때 생성)
            container.RegisterTransient<AuthPageView>();
            container.RegisterTransient<HomePageView>();
            container.RegisterTransient<LoginFormView>();
            container.RegisterTransient<HomeView>();
            container.RegisterTransient<NavView>();
        }

        /// <summary>
        /// VinetelMvvm 방식: Page와 Module을 분리하여 등록
        /// </summary>
        protected virtual void RegisterModules()
        {
            // ==== MainRegion에 Page들 등록 ====
            Manager.Register(Regions.MainRegion,
                new Module(PageViews.AuthPageView, AuthPageViewModel.Create, typeof(AuthPageView)));

            Manager.Register(Regions.MainRegion,
                new Module(PageViews.HomePageView, HomePageViewModel.Create, typeof(HomePageView)));

            // ==== 각 Region에 실제 Module들 등록 ====

            // AuthRegion에 LoginModule 등록
            Manager.Register(Regions.AuthRegion,
                new Module(Modules.LoginModule, LoginFormViewModel.Create, typeof(LoginFormView)));

            // HomeRegion에 HomeModule 등록
            Manager.Register(Regions.HomeRegion,
                new Module(Modules.HomeModule, HomeViewModel.Create, typeof(HomeView)));

            // NavRegion에 NavModule 등록
            Manager.Register(Regions.NavRegion,
                new Module(Modules.NavModule, NavViewModel.Create, typeof(NavView)));
        }

        /// <summary>
        /// VinetelMvvm 방식: 각 Region에 Module 주입
        /// </summary>
        protected virtual void InjectModules()
        {
            // 1. MainRegion에 AuthPage 주입
            Manager.Inject(Regions.MainRegion, PageViews.AuthPageView);

            // 2. AuthRegion에 LoginModule 주입
            Manager.Inject(Regions.AuthRegion, Modules.LoginModule);
        }
    }
}