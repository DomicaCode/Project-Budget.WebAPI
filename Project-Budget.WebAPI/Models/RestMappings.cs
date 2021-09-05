using AutoMapper;
using Project_Budget.Model.Models;
using Project_Budget.Model.Models.Membership;

namespace Project_Budget.WebAPI.Models
{
    public class RestMappings : Profile
    {
        #region Constructors

        public RestMappings()
        {
            CreateMap<User, RegistrationViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }

        #endregion Constructors
    }
}