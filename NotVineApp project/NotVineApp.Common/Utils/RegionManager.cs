using System.Windows;
using System.Windows.Controls;

namespace NotVineApp.Common.Utils
{
    public static class RegionManager
    {
        public static readonly DependencyProperty RegionNameProperty =
            DependencyProperty.RegisterAttached(
                "RegionName",
                typeof(string),
                typeof(RegionManager),
                new PropertyMetadata(null, OnRegionNameChanged));

        public static string GetRegionName(DependencyObject obj)
        {
            return (string)obj.GetValue(RegionNameProperty);
        }

        public static void SetRegionName(DependencyObject obj, string value)
        {
            obj.SetValue(RegionNameProperty, value);
        }

        private static void OnRegionNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ContentControl regionHost) return;

            // 이전 RegionName 해제
            if (e.OldValue is string oldName && !string.IsNullOrEmpty(oldName))
            {
                ModuleManager.DefaultManager.UnregisterRegion(oldName, regionHost);
            }

            if (e.NewValue is string regionName && !string.IsNullOrEmpty(regionName))
            {
                if (!regionHost.IsLoaded)
                {
                    regionHost.Loaded += (sender, args) => Register(regionName, regionHost);
                }
                else
                {
                    Register(regionName, regionHost);
                }

                // Unloaded 시 언레지스터
                regionHost.Unloaded += (sender, args) =>
                {
                    ModuleManager.DefaultManager.UnregisterRegion(regionName, regionHost);
                };
            }
        }

        private static void Register(string regionName, ContentControl regionHost)
        {
            ModuleManager.DefaultManager.RegisterRegion(regionName, regionHost);
        }
    }
}