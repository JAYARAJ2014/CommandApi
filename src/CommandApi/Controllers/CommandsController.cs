using System.Collections.Generic;
using AutoMapper;
using CommandApi.Data;
using CommandApi.Dtos;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get()
        {
            var cmdItems = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(cmdItems));
        }

        [HttpGet("{id}")]
        public ActionResult<Command> Get(int id)
        {
            var cmd = _repo.GetById(id);
            if (cmd == null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(cmd));
        }
    }

}