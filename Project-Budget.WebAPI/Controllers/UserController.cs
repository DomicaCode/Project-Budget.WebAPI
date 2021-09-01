using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Budget.Model.Models.Membership;
using Project_Budget.Service.Services.Membership;
using Project_Budget.WebAPI.Models;
using System.Threading.Tasks;

namespace Project_Budget.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Constructors

        public UserController(IUserService userService, IMapper mapper)
        {
            UserService = userService;
            Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        private IMapper Mapper { get; }
        private IUserService UserService { get; }

        #endregion Properties

        #region Methods

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            var user = Mapper.Map<User>(model);

            var response = await UserService.RegisterAsync(user).ConfigureAwait(false);

            return Ok(response);
        }

        #endregion Methods
    }
}