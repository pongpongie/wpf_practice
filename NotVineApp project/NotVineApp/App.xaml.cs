using NotVineApp.Common.Utils;
using NotVineApp.Common.Settings;
using NotVineAppGUI.HomeModule.ViewModels;
using NotVineAppGUI.HomeModule.Views;
using NotVineAppGUI.LoginModule.ViewModels;
using NotVineAppGUI.LoginModule.Views;
using NotVineAppGUI.NavModule.ViewModels;
using NotVineAppGUI.NavModule.Views;
using NotVineAppGUI.DemoModule.ViewModels;
using NotVineAppGUI.DemoModule.Views;
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

            container.RegisterTransient<AuthPageViewModel>();
            container.RegisterTransient<HomePageViewModel>();
            container.RegisterTransient<SelfTestPageViewModel>();

            container.RegisterTransient<LoginFormViewModel>();
            container.RegisterTransient<HomeViewModel>();
            container.RegisterTransient<NavViewModel>();
            container.RegisterTransient<SelfTestViewModel>();

            // 뷰들은 트랜지언트로 등록 (ModuleManager가 필요할 때 생성)
            container.RegisterTransient<AuthPageView>();
            container.RegisterTransient<HomePageView>();
            container.RegisterTransient<SelfTestPageView>();

            container.RegisterTransient<LoginFormView>();
            container.RegisterTransient<HomeView>();
            container.RegisterTransient<NavView>();
            container.RegisterTransient<SelfTestView>();

        }

        protected virtual void RegisterModules()
        {
            // ==== MainRegion에 Page들 등록 ====
            Manager.Register(Regions.MainRegion,
                new Module(PageViews.AuthPageView, AuthPageViewModel.Create, typeof(AuthPageView)));

            Manager.Register(Regions.MainRegion,
                new Module(PageViews.HomePageView, HomePageViewModel.Create, typeof(HomePageView)));

            Manager.Register(Regions.MainRegion,
                new Module(PageViews.SelfTestPageView, SelfTestPageViewModel.Create, typeof(SelfTestPageView)));

            // ==== 각 Region에 실제 Module들 등록 ====

            // LoginFormRegion
            Manager.Register(Regions.LoginFormRegion,
                new Module(Modules.LoginFormModule, LoginFormViewModel.Create, typeof(LoginFormView)));

            // HomeRegion
            Manager.Register(Regions.HomeRegion,
                new Module(Modules.HomeModule, HomeViewModel.Create, typeof(HomeView)));

            // NavRegion
            Manager.Register(Regions.NavRegion,
                new Module(Modules.NavModule, NavViewModel.Create, typeof(NavView)));

            // SelfTestRegion
            Manager.Register(Regions.SelfTestRegion,
                new Module(Modules.SelfTestModule, SelfTestViewModel.Create, typeof(SelfTestView)));
        }

        protected virtual void InjectModules()
        {
            Manager.Inject(Regions.SelfTestRegion, Modules.SelfTestModule);
            Manager.Inject(Regions.LoginFormRegion, Modules.LoginFormModule);
            Manager.Inject(Regions.NavRegion, Modules.NavModule);
            Manager.Inject(Regions.HomeRegion, Modules.HomeModule);

            Manager.Inject(Regions.MainRegion, PageViews.AuthPageView);
        }
    }
}