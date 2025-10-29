using NotVineApp.Common.Settings;
using NotVineApp.Common.Utils;
using System.Windows;
using System.Windows.Input;

namespace NotVineApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ModuleManager에 MainRegion 등록만 수행
            ModuleManager.DefaultManager.RegisterRegion(Regions.MainRegion, MainRegion);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}