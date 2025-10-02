using SeminarMvvmApp.Models;
using SeminarMvvmApp.Utils;
using SeminarMvvmApp.ViewModels;
using System.Windows;

namespace SeminarMvvmApp
{
    public partial class App : Application
    {
        //public static IocContainer Container { get; } = new IocContainer();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Model과 ViewModel 등록
            // POCO ViewModel을 사용할 때는 수동 등록이 필요하지 않은 것으로 리팩토링
            //Container.Register(() => new CounterModel());
            //Container.Register(() => new LogViewModel());
            //Container.Register(() => new CounterViewModel(Container.Resolve<CounterModel>()));
        }
    }
}
