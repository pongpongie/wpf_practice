using System.Windows.Controls;

namespace NotVineApp.Common.Services
{
    public interface INavigationService
    {
        void Initialize(ContentControl navigationFrame);
        void NavigateTo<T>() where T : UserControl;
        void NavigateTo(string viewKey);
    }
}