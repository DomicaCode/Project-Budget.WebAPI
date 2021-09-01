using AutoMapper;
using Project_Budget.Model.Models.Membership;

namespace Project_Budget.WebAPI.Models
{
    public class RestMappings : Profile
    {
        #region Constructors

        public RestMappings()
        {
            CreateMap<User, RegistrationViewModel>().ReverseMap();
        }

        #endregion Constructors
    }
}