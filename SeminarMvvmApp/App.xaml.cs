using DevExpress.Mvvm.ModuleInjection;
using DevExpress.Xpf.Core;
using SeminarMvvmApp.Models;
using SeminarMvvmApp.Utils;
using SeminarMvvmApp.ViewModels;
using SeminarMvvmApp.Views;
using System.Windows;

namespace SeminarMvvmApp
{
    public partial class App : Application
    {
        //public static IocContainer Container { get; } = new IocContainer();
        protected override void OnStartup(StartupEventArgs e)
        {
            ApplicationThemeHelper.ApplicationThemeName = Theme.NoneName;
            base.OnStartup(e);
            RegisterModules();
            InjectModules();
            // Model과 ViewModel 등록
            // POCO ViewModel을 사용할 때는 수동 등록이 필요하지 않은 것으로 리팩토링
            //Container.Register(() => new CounterModel());
            //Container.Register(() => new LogViewModel());
            //Container.Register(() => new CounterViewModel(Container.Resolve<CounterModel>()));
        }

        protected IModuleManager Manager { get { return ModuleManager.DefaultManager; } }

        protected virtual void RegisterModules()
        {
            Manager.Register("MainRegion", new Module("CounterPageView", CounterPageViewModel.Create, typeof(CounterPageView)));

            Manager.Register("LogRegion", new Module("LogModule", LogViewModel.Create, typeof(LogView)));
            Manager.Register("CounterRegion", new Module("CounterModule", CounterViewModel.Create, typeof(CounterView)));
        }

        protected virtual void InjectModules()
        {
            Manager.Inject("LogRegion", "LogModule");
            Manager.Inject("CounterRegion", "CounterModule");
            Manager.Inject("MainRegion", "CounterPageView");
        }
    }
}
