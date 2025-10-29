using System.Windows.Controls;
using NotVineApp.Common.Utils;

namespace NotVineApp.Common.Services
{
    public class NavigationService : INavigationService
    {
        private ContentControl? _navigationFrame;
        private readonly Dictionary<string, Type> _viewRegistry = new();

        public void Initialize(ContentControl navigationFrame)
        {
            _navigationFrame = navigationFrame;
        }

        public void RegisterView<T>(string key) where T : UserControl
        {
            _viewRegistry[key] = typeof(T);
        }

        public void NavigateTo<T>() where T : UserControl
        {
            if (_navigationFrame == null)
                throw new InvalidOperationException("NavigationService가 초기화되지 않았습니다.");

            var view = IoCContainer.Instance.Resolve<T>();
            _navigationFrame.Content = view;
        }

        public void NavigateTo(string viewKey)
        {
            if (_navigationFrame == null)
                throw new InvalidOperationException("NavigationService가 초기화되지 않았습니다.");

            if (!_viewRegistry.TryGetValue(viewKey, out var viewType))
                throw new InvalidOperationException($"뷰 키 '{viewKey}'가 등록되지 않았습니다.");

            var view = IoCContainer.Instance.Resolve(viewType) as UserControl;
            if (view == null)
                throw new InvalidOperationException($"'{viewKey}'에 대한 뷰를 생성할 수 없습니다.");

            _navigationFrame.Content = view;
        }
    }
}