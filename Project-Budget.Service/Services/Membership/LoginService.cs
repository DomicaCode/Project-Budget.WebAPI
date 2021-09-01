using Project_Budget.Common.Filters;
using Project_Budget.Model.Models.Authorization;
using Project_Budget.Service.Handlers.Password;
using Project_Budget.Service.Services.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services.Membership
{
    public class LoginService : ILoginService
    {
        public LoginService(IAuthorizationService authorizationService, IUserService userService)
        {
            AuthorizationService = authorizationService;
            UserService = userService;
        }

        public IAuthorizationService AuthorizationService { get; set; }
        public IUserService UserService { get; set; }

        public async Task<IToken> LoginAsync(string username, string password)
        {
            var filter = new UserFilter
            {
                Username = username
            };

            var user = await UserService.GetUserAsync(filter);
            if (user == null)
            {
                return default;
            }

            return PasswordHandler.VerifyPassword(password, user.HashedPassword, user.PasswordSalt) ?
                AuthorizationService.CreateToken(user)
                : default;
        }
    }
}
