using Microsoft.AspNetCore.Mvc;
using System;
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

        protected Guid GetUserId()
        {
            if (HttpContext.User == null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(HttpContext.User.Claims.Single(x => x.Type == "userId").Value);
        }

        #endregion Methods
    }
}