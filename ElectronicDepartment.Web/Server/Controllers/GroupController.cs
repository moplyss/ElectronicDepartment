﻿using ElectronicDepartment.BusinessLogic;
using ElectronicDepartment.Interfaces;
using ElectronicDepartment.Web.Shared.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ElectronicDepartment.Web.Shared.CafedraController;

namespace ElectronicDepartment.Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create(CreateGroupViewModel viewModel)
        {
            var id = await _groupService.Create(viewModel);

            return Ok(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var groupViewModel = await _groupService.Get(id);

            return Ok(groupViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetSelector()
        {
            var selector = await _groupService.GetSelector();

            return Ok(selector);
        }

        [HttpPut]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Update(UpdateGroupViewModel viewModel)
        {
            await _groupService.Update(viewModel);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetApiResponce(GetApiBodyRequest viewModel)
        {
            var responce = await _groupService.GetApiResponce(viewModel.PageIndex, viewModel.PageSize, viewModel.SortingRequests, viewModel.FilterRequests);

            return Ok(responce);
        }
    }
}