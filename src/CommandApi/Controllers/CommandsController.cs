using System.Collections.Generic;
using CommandApi.Data;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repo;

        public CommandsController(ICommandRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Command> Get(int id)
        {
            var cmd = _repo.GetById(id);
            if (cmd == null)
                return NotFound();

            return Ok(cmd);
        }
    }

}