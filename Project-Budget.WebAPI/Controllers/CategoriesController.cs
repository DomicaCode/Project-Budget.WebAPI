using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Budget.Model.Models;
using Project_Budget.Service.Services;
using Project_Budget.WebAPI.Controllers.Base;
using Project_Budget.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project_Budget.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            CategoryService = categoryService;
            Mapper = mapper;
        }

        public ICategoryService CategoryService { get; }
        public IMapper Mapper { get; }

        [HttpPost]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Model wrong", nameof(model));
            }

            var mappedModel = Mapper.Map<Category>(model);

            if (await CategoryService.AddAsync(mappedModel))
            {
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false });
        }

        [HttpDelete]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            if (categoryId == default)
            {
                throw new ArgumentException("Id wrong", nameof(categoryId));
            }

            if (await CategoryService.DeleteAsync(categoryId))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Model wrong", nameof(model));
            }

            var mappedModel = Mapper.Map<Category>(model);

            if (await CategoryService.EditAsync(mappedModel))
            {
                return Ok();
            }
            return BadRequest(new { success = false });
        }

    }
}
