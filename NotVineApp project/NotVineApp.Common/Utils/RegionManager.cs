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
            if (d is ContentControl regionHost && e.NewValue is string regionName)
            {
                if (!string.IsNullOrEmpty(regionName))
                {
                    // 컨트롤이 로드된 후에 등록하도록 보장합니다.
                    if (!regionHost.IsLoaded)
                    {
                        regionHost.Loaded += (sender, args) => Register(regionName, regionHost);
                    }
                    else
                    {
                        Register(regionName, regionHost);
                    }
                }
            }
        }

        private static void Register(string regionName, ContentControl regionHost)
        {
            ModuleManager.DefaultManager.RegisterRegion(regionName, regionHost);
        }
    }
}