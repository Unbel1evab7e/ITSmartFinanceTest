using ITSmartFinance.Models.Models;
using ITSmartFinance.Models.Wrappers;
using ITSmartFinance.Services.IService;
using ITSmartFinanceTest.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSmartFinanceTest.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        private readonly ITaskOnUserService _taskOnUserService;
        public TaskController(ITaskService service, ITaskOnUserService taskOnUserService)
        {
            _service = service;
            _taskOnUserService = taskOnUserService;
        }
        // GET: api/v1/Task/GetAll
        [HttpGet("GetAll")]
        public ActionResult<Response<IEnumerable<Data.Entities.Task>>> GetAll()
        {
            var result = _service.GetAllTasks();
            if (result.Count() == 0)
                return NotFound(new Response<IEnumerable<Data.Entities.Task>>("Models array are empty!"));
            return Ok(new Response<IEnumerable<Data.Entities.Task>>(result));
        }

        // GET api/v1/Task/GetById?id=
        [HttpGet("GetById")]
        public async Task<ActionResult<Response<Data.Entities.Task>>> GetById([FromQuery] Guid id)
        {
            var result = await _service.GetTask(id);
            if (result == null)
                return NotFound(new Response<Data.Entities.Task>("Models not found!"));
            return Ok(new Response<Data.Entities.Task>(result));
        }
        // GET: api/v1/Task/GetAllRelations
        [HttpGet("GetAllRelations")]
        public ActionResult<Response<IEnumerable<TaskOnUser>>> GetAllRelations()
        {
            var result = _taskOnUserService.GetAllEntities();
            if (result.Count() == 0)
                return NotFound(new Response<IEnumerable<TaskOnUser>>("Models array are empty!"));
            return Ok(new Response<IEnumerable<TaskOnUser>>(result));
        }
        // GET: api/v1/Task/GetUserTasks&id=
        [HttpGet("GetUserTasks")]
        public ActionResult<Response<IEnumerable<Data.Entities.Task>>> GetUserTasks([FromQuery] Guid id)
        {
            var result=_service.GetTaskByUserId(id);
            if (result.Count() == 0)
                return NotFound(new Response<IEnumerable<Data.Entities.Task>>("Models array are empty!"));
            return Ok(new Response<IEnumerable<Data.Entities.Task>>(result));
        }
        // POST api/v1/Task/Create
        [HttpPost("Create")]
        public async Task<ActionResult<Response<Data.Entities.Task>>> Create([FromBody] TaskCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<Data.Entities.Task>("Invalid model!"));
            return Ok(new Response<Data.Entities.Task>(await _service.CreateTask(model)));
        }

        // POST api/v1/Task/Update
        [HttpPost("Update")]
        public async Task<ActionResult<Response<Data.Entities.Task>>> Update([FromBody] TaskUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<Data.Entities.Task>("Invalid model!"));
            return Ok(new Response<Data.Entities.Task>(await _service.UpdateTask(model)));
        }
        // POST api/v1/Task/AddUsersToTask
        [HttpPost("AddUsersToTask")]
        public async Task<ActionResult<Response<bool>>> AddUsersToTask([FromBody] RelationCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<bool>("Invalid model!"));
            return Ok(new Response<bool>(await _taskOnUserService.AddRelation(model)));
        }

        // DELETE api/v1/Task/Delete/id
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(Guid id)
        {
            return Ok(new Response<bool>(await _service.DeleteTask(id)));
        }
      
        // DELETE api/v1/Task/DeleteUserFromTask/id
        [HttpDelete("DeleteUserFromTask/{id}")]
        public async Task<ActionResult<Response<bool>>> DeleteUserFromTask(Guid id)
        {
            return Ok(new Response<bool>(await _taskOnUserService.DeleteRelation(id)));
        }
     

    }
}
