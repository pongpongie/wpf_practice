using NotVineApp.Common.Settings;
using NotVineApp.Common.Utils;
using NotVineAppGUI.RegionPageView.ViewModels;
using System.Windows.Controls;

namespace NotVineAppGUI.RegionPageView.Views
{
    public partial class AuthPageView : UserControl
    {
        public AuthPageView()
        {
            InitializeComponent();

            // Region 등록 (VinetelMvvm 방식)
            ModuleManager.DefaultManager.RegisterRegion(Regions.AuthRegion, AuthRegion);
        }
    }
}