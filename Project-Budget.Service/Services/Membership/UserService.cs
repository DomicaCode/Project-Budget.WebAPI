using Project_Budget.Common.Filters;
using Project_Budget.Model.Models.Membership;
using Project_Budget.Model.Response;
using Project_Budget.Repository.Repositories;
using Project_Budget.Service.Handlers.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services.Membership
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; set; }

        public async Task<User> GetUserAsync(UserFilter filter)
        {
            return await UserRepository.GetAsync(filter).ConfigureAwait(false);
        }

        public async Task<BaseResponse> RegisterAsync(User user)
        {
            var response = new BaseResponse();

            var filter = new UserFilter
            {
                Username = user.Username,
                Email = user.Email
            };

            var currentUser = await GetUserAsync(filter).ConfigureAwait(false);

            if (currentUser != null)
            {
                throw new Exception("User already exists");
            }

            var hashedPassword = PasswordHandler.GenerateSaltedHash(64, user.Password);

            user.HashedPassword = hashedPassword.Hash;
            user.PasswordSalt = hashedPassword.Salt;

            await UserRepository.InsertAsync(user);

            response.IsSuccess = true;
            response.Message = "User successfully added";

            return response;
        }
    }
}
