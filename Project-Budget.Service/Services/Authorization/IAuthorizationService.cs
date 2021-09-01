using Project_Budget.Model.Models.Authorization;
using Project_Budget.Model.Models.Membership;

namespace Project_Budget.Service.Services.Authorization
{
    public interface IAuthorizationService
    {
        IToken CreateToken(User user);
    }
}