using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Project_Budget.WebAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        #region Fields

        private readonly string _apiBase = "api";

        private readonly string _apiVersion = "v1";

        #endregion Fields

        #region Properties

        protected string BaseRoute { get { return $"{_apiBase}/{_apiVersion}"; } }

        #endregion Properties

        #region Methods

        protected string GetUserId()
        {
            if (HttpContext.User == null)
            {
                return string.Empty;
            }

            return HttpContext.User.Claims.Single(x => x.Type == "userId").Value;
        }

        #endregion Methods
    }
}