using Project_Budget.Model.Models.Authorization;
using Project_Budget.Service.Services.Authorization;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services.Membership
{
    public interface ILoginService
    {
        IAuthorizationService AuthorizationService { get; set; }
        IUserService UserService { get; set; }

        Task<IToken> LoginAsync(string username, string password);
    }
}