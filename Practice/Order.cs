//using System.ComponentModel;
//using System.Windows.Input;

//public class Order
//{
//    public decimal Price { get; set; }
//    public int Quantity { get; set; }
//    public decimal DiscountRate { get; set; }
//    public decimal GetTotal() => Price * Quantity * (1 - DiscountRate); // 총액 계산
//    public bool IsValid() => Quantity > 0 && Price > 0; // 유효성 검사
//    public void CompleteOrder()
//    {
//        // 결제 처리, 상태 변경 등
//    }
//}

//public class OrderViewModel : INotifyPropertyChanged
//{
//    private Order _order;
//    public decimal Price
//    {
//        get => _order.Price;
//        set { _order.Price = value; OnPropertyChanged(); OnPropertyChanged(nameof(Total)); }
//    }
//    public int Quantity
//    {
//        get => _order.Quantity;
//        set { _order.Quantity = value; OnPropertyChanged(); OnPropertyChanged(nameof(Total)); }
//    }
//    public decimal Total => _order.GetTotal(); // Model의 비즈니스 로직 활용
//    public string TotalDisplay => $"총액: {Total:C}"; // UI용 데이터 가공
//    public bool IsInputValid => Price > 0 && Quantity > 0; // 단순 입력 검증
//    public ICommand SubmitOrderCommand => new RelayCommand(SubmitOrder, () => IsInputValid);
//    private void SubmitOrder()
//    {
//        if (_order.IsValid())
//        {
//            _order.CompleteOrder(); // Model의 비즈니스 로직 호출
//                                    // 상태 메시지, 알림 등 UI 관련 처리
//                                    // 네트워크 요청, 상태 관리, 에러 처리 등
//        }
//    }
//}
