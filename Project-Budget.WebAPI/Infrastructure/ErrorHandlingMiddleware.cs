using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Project_Budget.Model.Response;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Project_Budget.WebAPI.Infrastructure
{
    public class ErrorHandlingMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;

        #endregion Fields

        #region Constructors

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new BaseResponse
            {
                Error = ex.Message,
                IsSuccess = false,
            };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var result = JsonConvert.SerializeObject(response, serializerSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            return context.Response.WriteAsync(result);
        }

        #endregion Methods
    }
}