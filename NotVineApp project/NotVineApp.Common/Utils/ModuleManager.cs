using NotVineApp.Common.Utils;
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
            // Region이 등록되었으므로, 이 Region을 기다리던 보류된 주입 요청을 실행합니다.
            ProcessPendingInjections(regionName);
        }

        public void Inject(string regionName, string moduleName)
        {
            // Region이 이미 등록되어 있다면 즉시 주입합니다.
            if (_regions.TryGetValue(regionName, out var regionHost))
            {
                PerformInjection(regionHost, regionName, moduleName);
            }
            else
            {
                // Region이 아직 없다면, 나중을 위해 주입 요청을 보류 목록에 추가합니다.
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
            if (_pendingInjections.TryGetValue(regionName, out var pendingModules) && _regions.TryGetValue(regionName, out var regionHost))
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
                    var view = IoCContainer.Instance.Resolve(moduleToInject.ViewType);
                    regionHost.Content = view;
                }
            }
        }
    }
}