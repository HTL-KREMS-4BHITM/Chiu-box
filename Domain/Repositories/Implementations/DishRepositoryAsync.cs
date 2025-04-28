using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class DishRepositoryAsync : ARepositoryAsync<Dish>
{
    public DishRepositoryAsync(DishContext context) : base(context)
    {
    }
}