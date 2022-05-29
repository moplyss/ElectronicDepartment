﻿using ElectronicDepartment.BusinessLogic;
using ElectronicDepartment.Interfaces;
using ElectronicDepartment.Web.Shared.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ElectronicDepartment.Web.Shared.CafedraController;

namespace ElectronicDepartment.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager, teacher")]
        public async Task<IActionResult> Create(CreateCourseViewModel viewModel)
        {
            var id = await _courseService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var CourseViewModel = await _courseService.Get(id);

            return Ok(CourseViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSelector(int id)
        {
            var selector = await _courseService.GetSelector();

            return Ok(selector);
        }

        [HttpPut]
        [Authorize(Roles = "admin, manager, teacher")]
        public async Task<IActionResult> Update(UpdateCourseViewModel viewModel)
        {
            await _courseService.Update(viewModel);

            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _courseService.GetApiResponce(viewModel.PageIndex, viewModel.PageSize, viewModel.SortingRequests, viewModel.FilterRequests);

            return Ok(responce);
        }
    }
}