using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class ScheduleRepoAsnyc:ARepositoryAsync<ShopSchedule>
{
    public ScheduleRepoAsnyc(DishContext context) : base(context)
    {
    }
}