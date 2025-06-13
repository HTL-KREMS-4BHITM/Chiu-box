public interface IShoppingCartService
{
    int ItemCount { get; }
    decimal TotalPrice { get; set; }
    event Action OnCartUpdated;
    void AddItem();
}

public class ShoppingCartService : IShoppingCartService
{
    private int _itemCount;
    private decimal _totalPrice;
    public int ItemCount => _itemCount;

    public decimal TotalPrice
    {
        get => _totalPrice;
        set => _totalPrice = value;
    }
    public event Action OnCartUpdated;

    public void AddItem()
    {
        _itemCount++;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnCartUpdated?.Invoke();
}