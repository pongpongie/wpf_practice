using NotVineApp.Common.Utils;

public class HomePageViewModel : ViewModelBase
{
    public HomePageViewModel()
    {
        // 아무 의존성 없음 - 단순 레이아웃 제공
    }

    public static HomePageViewModel Create()
    {
        return new HomePageViewModel();
    }
}