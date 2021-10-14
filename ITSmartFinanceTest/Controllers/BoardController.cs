using ITSmartFinance.Models.Models;
using ITSmartFinance.Models.Wrappers;
using ITSmartFinance.Services.IService;
using ITSmartFinanceTest.Data;
using ITSmartFinanceTest.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITSmartFinanceTest.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _service;
        private readonly ITaskService _taskService;
        private readonly AppDbContext _context;
        public BoardController(IBoardService service,ITaskService taskService,AppDbContext context)
        {
            _service = service;
            _taskService = taskService;
            _context = context;
        }
        // GET: api/v1/Board/GetAll
        [HttpGet("GetAll")]
        public ActionResult<Response<IEnumerable<Board>>> GetAll()
        {
            var result = _service.GetAllBoards();
            if (result.Count() == 0)
                return NotFound(new Response<IEnumerable<Board>>("Models array are empty!"));
            return Ok(new Response<IEnumerable<Board>>(result));
        }
        // GET: api/v1/Board/GetBoardsByTasksCount
        [HttpGet("GetBoardsByTasksCount")]
        public ActionResult<Response<IEnumerable<Board>>> GetBoardsByTasksCount([FromQuery] int count)
        {
            var result  = _service.GetBoardsByTaskCount(count);
            if (result.Count() == 0)
                return NotFound(new Response<IEnumerable<Board>>("Models array are empty!"));
            return Ok(new Response<IEnumerable<Board>>(result));

        }
        // GET: api/v1/Board/GetAvgCountOfTasks
        [HttpGet("GetAvgCountOfTasks")]
        public ActionResult<Response<double>>GetAvgCountOfTasks()
        {
            var result = _service.GetAvgTaskCount();
            if (Double.IsNaN(result)) 
                return BadRequest(new Response<double>("Result is NaN"));
            return Ok(new Response<double>(result));
                

        }

        // GET api/v1/Board/GetById?id=
        [HttpGet("GetById")]
        public async Task<ActionResult<Response<Board>>> GetById([FromQuery]Guid id)
        {
            var result = await _service.GetBoard(id);
            if (result == null)
                return NotFound(new Response<Board>("Models not found!"));
            return Ok(new Response<Board>(result));
        }

        // POST api/v1/Board/Create
        [HttpPost("Create")]
        public async Task<ActionResult<Response<Board>>> Create([FromBody] BoardCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<Board>("Invalid model!"));
            return Ok(new Response<Board>(await _service.CreateBoard(model)));
        }

        // POST api/v1/Board/Update
        [HttpPost("Update")]
        public async Task<ActionResult<Response<Board>>> Update([FromBody] BoardUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<Board>("Invalid model!"));
            return Ok(new Response<Board>(await _service.UpdateBoard(model)));
        }
        
        // POST api/v1/Board/AddTaskToBoard
        [HttpPost("AddTaskToBoard")]
        public async Task<ActionResult<Response<Data.Entities.Task>>> AddTaskToBoard([FromBody] AdditionTaskToBoardModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<Board>("Invalid model!"));
            var task = await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==model.TaskId);
            return Ok(new Response<Data.Entities.Task>(await _taskService.UpdateTask(new TaskUpdateModel { BoardId = model.BoardId, Description = task.Description, Id = task.Id })));
        }

        // Delete api/v1/Board/DeleteTaskFromBoard
        [HttpDelete("DeleteTaskFromBoard/{taskId}")]
        public async Task<ActionResult<Response<Data.Entities.Task>>> DeleteTaskFromBoard(Guid taskId)
        {
            var task = await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == taskId);
            return Ok(new Response<Data.Entities.Task>(await _taskService.UpdateTask(new TaskUpdateModel { BoardId = null, Description = task.Description, Id = task.Id })));
        }

        // DELETE api/v1/Board/Delete/id
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(Guid id)
        {
            return Ok(new Response<bool>(await _service.DeleteBoard(id)));
        }
    }
}
