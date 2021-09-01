using Project_Budget.Common.Filters;
using Project_Budget.Model.Models.Membership;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public interface IUserRepository : IBaseRepository<User, UserFilter>
    {
    }
}