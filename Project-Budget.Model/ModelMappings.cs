using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Project_Budget.Model.Models.Authorization;

namespace Project_Budget.Model
{
    public class ModelMappings : Profile
    {
        #region Constructors

        public ModelMappings()
        {
            CreateMap<SecurityToken, Token>().ReverseMap();
            CreateMap<SecurityToken, IToken>().ReverseMap();

            CreateMap<Token, IToken>().ReverseMap();
        }

        #endregion Constructors
    }
}