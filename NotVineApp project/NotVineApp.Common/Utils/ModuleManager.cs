using NotVineApp.Common.Services;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace NotVineApp.Common.Utils
{
    public class ModuleManager
    {
        private static ModuleManager _defaultManager;
        public static ModuleManager DefaultManager => _defaultManager ??= new ModuleManager();

        private readonly Dictionary<string, List<Module>> _regionModules = new();
        private readonly Dictionary<string, ContentControl> _regions = new();
        private readonly IoCContainer _container;
        

        public ModuleManager()
        {
            _container = IoCContainer.Instance;
            
        }

        // Region 컨트롤 등록
        public void RegisterRegion(string regionKey, ContentControl contentControl)
        {
            _regions[regionKey] = contentControl;
        }

        // Region에 Module 등록
        public void Register(string regionKey, Module module)
        {
            if (!_regionModules.ContainsKey(regionKey))
            {
                _regionModules[regionKey] = new List<Module>();
            }

            _regionModules[regionKey].Add(module);

            // Container에 ViewModel 등록
            _container.RegisterTransient(module.ViewModelFactory);

            // Container에 View 등록
            _container.RegisterTransient(() =>
            {
                var view = Activator.CreateInstance(module.ViewType) as UserControl;
                if (view != null)
                {
                    view.DataContext = module.ViewModelFactory();
                }
                return view;
            });
        }

        // Region에 Module 주입
        public void Inject(string regionKey, string moduleKey)
        {
            if (!_regionModules.ContainsKey(regionKey))
            {
                throw new InvalidOperationException($"Region '{regionKey}' not found.");
            }

            var module = _regionModules[regionKey].FirstOrDefault(m => m.Key == moduleKey);
            if (module == null)
            {
                throw new InvalidOperationException($"Module '{moduleKey}' not found in region '{regionKey}'.");
            }

            // Region이 등록되어 있으면 직접 주입
            if (_regions.ContainsKey(regionKey))
            {
                var view = Activator.CreateInstance(module.ViewType) as UserControl;
                if (view != null)
                {
                    view.DataContext = module.ViewModelFactory();
                    _regions[regionKey].Content = view;
                }
            }
        }

        public IEnumerable<Module> GetModules(string regionKey)
        {
            return _regionModules.ContainsKey(regionKey)
                ? _regionModules[regionKey]
                : Enumerable.Empty<Module>();
        }
    }
}