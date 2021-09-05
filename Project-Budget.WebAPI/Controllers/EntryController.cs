using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Budget.Common;
using Project_Budget.Model.Models;
using Project_Budget.Service.Services;
using Project_Budget.WebAPI.Controllers.Base;
using Project_Budget.WebAPI.Models;
using System;
using System.Threading.Tasks;

namespace Project_Budget.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : BaseController
    {
        public EntryController(IEntryService entryService, IMapper mapper)
        {
            EntryService = entryService;
            Mapper = mapper;
        }

        public IEntryService EntryService { get; }
        public IMapper Mapper { get; }

        [HttpPost]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(EntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Model wrong", nameof(model));
            }

            var mappedModel = Mapper.Map<Entry>(model);
            mappedModel.UserId = GetUserId();

            if (await EntryService.AddAsync(mappedModel))
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
            var result = await EntryService.GetAllAsync(new ExtendedFilter { UserId = GetUserId() }).ConfigureAwait(false);

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

            var result = await EntryService.GetAsync(new ExtendedFilter { Id = id, UserId = GetUserId() });

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

            if (await EntryService.DeleteAsync(typeId))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(EntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Model wrong", nameof(model));
            }

            var mappedModel = Mapper.Map<Entry>(model);

            if (await EntryService.EditAsync(mappedModel))
            {
                return Ok();
            }
            return BadRequest(new { success = false });
        }

    }
}
