using Model.Entites;

public interface IShoppingCartService
{

    decimal TotalPrice { get; set; }
    event Action OnCartUpdated;
    void AddItem(Dish dish);
}

public class ShoppingCartService : IShoppingCartService
{
    private decimal _totalPrice;


    public decimal TotalPrice
    {
        get => _totalPrice;
        set => _totalPrice = value;
    }
    public event Action OnCartUpdated;

    public void AddItem(Dish dish)
    {
        Console.WriteLine("Start Cart");
        TotalPrice += dish.Price;
        NotifyStateChanged();
        Console.WriteLine("End Cart");
    }
    
    
    private void NotifyStateChanged() => OnCartUpdated?.Invoke();
}