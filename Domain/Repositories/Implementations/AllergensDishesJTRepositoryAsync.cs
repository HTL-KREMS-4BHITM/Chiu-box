using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class AllergensDishesJTRepositoryAsync:ARepositoryAsync<AllergenDishesJT>
{
    public AllergensDishesJTRepositoryAsync(DishContext context) : base(context)
    {
    }
}