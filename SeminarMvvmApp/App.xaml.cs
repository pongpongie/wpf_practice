using SeminarMvvmApp.Models;
using SeminarMvvmApp.Utils;
using SeminarMvvmApp.ViewModels;
using System.Windows;

namespace SeminarMvvmApp
{
    public partial class App : Application
    {
        public static IocContainer Container { get; } = new IocContainer();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Model과 ViewModel 등록
            Container.Register(() => new CounterModel());
            Container.Register(() => new CounterViewModel(Container.Resolve<CounterModel>()));
        }
    }
}
