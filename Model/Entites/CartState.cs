public class CartState
{
    private decimal _totalPrice = 0;
    public event Action? OnChange;
    public decimal TotalPrice 
    {
        get => _totalPrice;
        set
        {
            if (_totalPrice != value)
            {
                _totalPrice = value;
                NotifyStateChanged();
            }
        }
    }
    
    private void NotifyStateChanged() 
    {
        Console.WriteLine($"CartState: TotalPrice changed to {_totalPrice}");
        Console.WriteLine($"CartState: Number of subscribers = {OnChange?.GetInvocationList()?.Length ?? 0}");
        OnChange?.Invoke();
    }

    public void AddToTotal(decimal price)
    {
        TotalPrice += price;
    }
}