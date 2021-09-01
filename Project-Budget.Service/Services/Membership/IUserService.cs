using Project_Budget.Common.Filters;
using Project_Budget.Model.Models.Membership;
using Project_Budget.Model.Response;
using Project_Budget.Repository.Repositories;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services.Membership
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }

        Task<User> GetUserAsync(UserFilter filter);
        Task<BaseResponse> RegisterAsync(User user);
    }
}