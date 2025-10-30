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
        // 각 Region에 마지막으로 주입된 모듈을 기억
        private readonly Dictionary<string, string> _currentModuleByRegion = [];

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
            // 기존 호스트와 동일하면 무시, 다르면 교체
            if (_regions.TryGetValue(regionName, out var existingHost))
            {
                if (ReferenceEquals(existingHost, regionHost)) return;
                _regions[regionName] = regionHost;
            }
            else
            {
                _regions.Add(regionName, regionHost);
            }

            // 대기 중인 주입이 있으면 먼저 처리
            if (_pendingInjections.ContainsKey(regionName))
            {
                ProcessPendingInjections(regionName);
            }
            else if (_currentModuleByRegion.TryGetValue(regionName, out var currentModule))
            {
                // 마지막 모듈을 새 호스트에 재주입
                PerformInjection(regionHost, regionName, currentModule);
            }
        }

        public void UnregisterRegion(string regionName, ContentControl regionHost)
        {
            if (_regions.TryGetValue(regionName, out var existing) && ReferenceEquals(existing, regionHost))
            {
                _regions.Remove(regionName);
                // _currentModuleByRegion 는 유지(다음에 같은 regionName이 다시 뜨면 재주입)
            }
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

            // 마지막 모듈 기록
            _currentModuleByRegion[regionName] = moduleName;
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

                        // 마지막 모듈 갱신
                        _currentModuleByRegion[regionName] = moduleName;
                    }
                }
            }
        }
    }
}