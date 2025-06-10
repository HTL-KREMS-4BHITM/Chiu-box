using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class DishesOrdersRepo : ARepositoryAsync<DishesOrderJT>
{
    public DishesOrdersRepo(DishContext context) : base(context)
    {
    }
}