using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using static Practice.MyViewModel;

public class Order
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal DiscountRate { get; set; }
    public string Status { get; private set; }

    // 총액 계산 (비즈니스 규칙)
    public decimal GetTotal() => Price * Quantity * (1 - DiscountRate);

    // 주문 유효성 검사 (비즈니스 규칙)
    public bool IsValid() => Quantity > 0 && Price > 0 && DiscountRate >= 0 && DiscountRate < 1;

    // 주문 상태 변경 (비즈니스 규칙)
    public void CompleteOrder()
    {
        if (IsValid()) Status = "Completed";
    }
}


public class OrderViewModel : INotifyPropertyChanged
{
    private Order _order;
    public OrderViewModel()
    {
        _order = new Order();
    }

    // UI 바인딩용 속성
    public decimal Price
    {
        get => _order.Price;
        set { _order.Price = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalDisplay)); }
    }
    public int Quantity
    {
        get => _order.Quantity;
        set { _order.Quantity = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalDisplay)); }
    }
    public decimal DiscountRate
    {
        get => _order.DiscountRate;
        set { _order.DiscountRate = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalDisplay)); }
    }

    // UI에 표시할 데이터 가공
    public string TotalDisplay => $"총액: {_order.GetTotal():C}";

    // 단순 입력값 검증 (UI 반응용)
    public bool IsInputValid => Price > 0 && Quantity > 0 && DiscountRate >= 0 && DiscountRate < 1;

    // 커맨드 처리
    public ICommand SubmitOrderCommand => new RelayCommand(SubmitOrder, () => IsInputValid);
    private void SubmitOrder()
    {
        if (_order.IsValid())
        {
            _order.CompleteOrder();
            StatusMessage = "주문이 완료되었습니다.";
        }
        else
        {
            StatusMessage = "입력값을 확인하세요.";
        }
        OnPropertyChanged(nameof(StatusMessage));
    }

    // 상태 관리
    public string StatusMessage { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
