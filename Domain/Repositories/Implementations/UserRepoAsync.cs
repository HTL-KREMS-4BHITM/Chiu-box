using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class UserRepoAsync:ARepositoryAsync<User>
{
    public UserRepoAsync(DishContext context) : base(context)
    {
    }
}