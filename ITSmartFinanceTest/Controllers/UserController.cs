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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        // GET: api/v1/User/GetAll
        [HttpGet("GetAll")]
        public ActionResult<Response<IEnumerable<User>>> GetAll()
        {
            var result =_service.GetAllUsers();
            if (result.Count() == 0)
                return NotFound(new Response<IEnumerable<User>>("Models array are empty!"));
            return Ok(new Response<IEnumerable<User>>(result));
        }

        // GET api/v1/User/GetById?id=
        [HttpGet("GetById")]
        public async Task<ActionResult<Response<User>>> GetById([FromQuery] Guid id)
        {
            var result = await _service.GetUser(id);
            if (result==null)
                return NotFound(new Response<User>("Models not found!"));
            return Ok(new Response<User>(result));
        }

        // POST api/v1/User/Create
        [HttpPost("Create")]
        public async Task<ActionResult<Response<User>>> Create([FromBody] UserCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<User>("Invalid model!"));
            return Ok(new Response<User>(await _service.CreateUser(model)));
           
        }

        // POST api/v1/User/Update
        [HttpPost("Update")]
        public async Task<ActionResult<Response<User>>> Update([FromBody] UserUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<User>("Invalid model!"));
            return Ok(new Response<User>(await _service.UpdateUser(model)));
        }

        // DELETE api/v1/User/Delete/id
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(Guid id)
        {
            return Ok(new Response<bool>(await _service.DeleteUser(id)));
        }
    }
}
