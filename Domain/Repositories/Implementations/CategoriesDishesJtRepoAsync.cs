using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class CategoriesDishesJtRepoAsync : ARepositoryAsync<CategoriesDishesJT>
{
    public CategoriesDishesJtRepoAsync(DishContext context) : base(context)
    {
    }
}