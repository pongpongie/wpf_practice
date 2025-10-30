using System.Windows;
using System.Windows.Controls;

namespace NotVineApp.Common.Utils
{
    public class ModuleManager
    {
        private static readonly Lazy<ModuleManager> _lazy = new(() => new ModuleManager());
        public static ModuleManager DefaultManager => _lazy.Value;

        private readonly Dictionary<string, List<Module>> _moduleRegistry = [];
        private readonly Dictionary<string, ContentControl> _regions = [];
        private readonly Dictionary<string, List<string>> _pendingInjections = [];

        private ModuleManager() { }

        public void Register(string regionName, Module module)
        {
            if (!_moduleRegistry.TryGetValue(regionName, out var modules))
            {
                modules = [];
                _moduleRegistry[regionName] = modules;
            }
            modules.Add(module);
        }

        public void RegisterRegion(string regionName, ContentControl regionHost)
        {
            if (_regions.ContainsKey(regionName)) return;

            _regions.Add(regionName, regionHost);
            ProcessPendingInjections(regionName);
        }

        public void Inject(string regionName, string moduleName)
        {
            if (_regions.TryGetValue(regionName, out var regionHost))
            {
                PerformInjection(regionHost, regionName, moduleName);
            }
            else
            {
                if (!_pendingInjections.TryGetValue(regionName, out var pending))
                {
                    pending = [];
                    _pendingInjections[regionName] = pending;
                }
                pending.Add(moduleName);
            }
        }

        private void ProcessPendingInjections(string regionName)
        {
            if (_pendingInjections.TryGetValue(regionName, out var pendingModules) &&
                _regions.TryGetValue(regionName, out var regionHost))
            {
                foreach (string moduleName in pendingModules)
                {
                    PerformInjection(regionHost, regionName, moduleName);
                }
                _pendingInjections.Remove(regionName);
            }
        }

        private void PerformInjection(ContentControl regionHost, string regionName, string moduleName)
        {
            if (_moduleRegistry.TryGetValue(regionName, out var modules))
            {
                var moduleToInject = modules.FirstOrDefault(m => m.Key == moduleName);
                if (moduleToInject != null)
                {
                    var viewObj = IoCContainer.Instance.Resolve(moduleToInject.ViewType);
                    if (viewObj is FrameworkElement view)
                    {
                        // ViewModelFactory로 VM 생성 후 DataContext 설정
                        var vm = moduleToInject.ViewModelFactory?.Invoke();
                        if (vm is not null)
                        {
                            view.DataContext = vm;
                        }
                        regionHost.Content = view;
                    }
                }
            }
        }
    }
}