using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Budget.Common;
using Project_Budget.Service.Services;
using Project_Budget.WebAPI.Controllers.Base;
using Project_Budget.WebAPI.Models;
using System;
using System.Threading.Tasks;

namespace Project_Budget.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : BaseController
    {
        public TypeController(ITypeService typeService, IMapper mapper)
        {
            TypeService = typeService;
            Mapper = mapper;
        }

        public ITypeService TypeService { get; }
        public IMapper Mapper { get; }

        [HttpPost]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(TypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Model wrong", nameof(model));
            }

            var mappedModel = Mapper.Map<Model.Models.Type>(model);
            mappedModel.UserId = GetUserId();

            if (await TypeService.AddAsync(mappedModel))
            {
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false });
        }

        [HttpGet]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAll()
        {
            var result = await TypeService.GetAllAsync(new ExtendedFilter { UserId = GetUserId() }).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException("Id wrong", nameof(id));
            }

            var result = await TypeService.GetAsync(new ExtendedFilter { Id = id, UserId = GetUserId() });

            return Ok(result);
        }

        [HttpDelete]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(Guid typeId)
        {
            if (typeId == default)
            {
                throw new ArgumentException("Id wrong", nameof(typeId));
            }

            if (await TypeService.DeleteAsync(typeId))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(TypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Model wrong", nameof(model));
            }

            var mappedModel = Mapper.Map<Model.Models.Type>(model);

            if (await TypeService.EditAsync(mappedModel))
            {
                return Ok();
            }
            return BadRequest(new { success = false });
        }

    }
}
