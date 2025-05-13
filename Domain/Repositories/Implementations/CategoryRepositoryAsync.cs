using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class CategoryRepositoryAsync : ARepositoryAsync<Category>
{
    public CategoryRepositoryAsync(DishContext context) : base(context)
    {
    }
}