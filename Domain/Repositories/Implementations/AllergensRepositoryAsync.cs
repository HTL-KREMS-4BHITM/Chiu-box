using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class AllergensRepositoryAsync:ARepositoryAsync<Allergens>
{
    public AllergensRepositoryAsync(DishContext context) : base(context)
    {
    }
}