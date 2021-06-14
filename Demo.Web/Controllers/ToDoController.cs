using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository repository)
        {
            _toDoRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var res = _toDoRepository.GetAllToDos();
            return Ok(res);
        }

    }
}