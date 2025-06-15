using Model.Entites;

public interface IShoppingCartService
{
    List<Dish> Dishes { get; }
    decimal TotalPrice { get; set; }
    event Action OnCartUpdated;
    void AddItem(Dish dish);
}

public class ShoppingCartService : IShoppingCartService
{
    private List<Dish> _dishes = new List<Dish>();
    private decimal _totalPrice;
    public List<Dish> Dishes => _dishes;

    public decimal TotalPrice
    {
        get => _totalPrice;
        set => _totalPrice = value;
    }
    public event Action OnCartUpdated;

    public void AddItem(Dish dish)
    {
        Dishes.Add(dish);
        UpdatePrice();
        NotifyStateChanged();
    }

    public void UpdatePrice()
    {
        foreach (var item in Dishes)
        {
            _totalPrice += item.Price;
        }
    }
    
    private void NotifyStateChanged() => OnCartUpdated?.Invoke();
}