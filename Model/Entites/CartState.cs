public class CartState
{
    public decimal TotalPrice { get; private set; }
    public event Action? OnChange;

    public void AddToTotal(decimal price)
    {
        TotalPrice += price;
        OnChange?.Invoke(); // No Dispatcher here!
    }
}