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

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Command> GetById(int id)
        {
            var cmd = _repo.GetById(id);
            if (cmd == null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(cmd));
        }

        [HttpPost]
        public ActionResult<CommandCreateDto> Create(CommandCreateDto dto)
        {
            var model = _mapper.Map<Command>(dto);
            _repo.Create(model);
            _repo.SaveChanges();

            var readDto = _mapper.Map<CommandReadDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpPut]
        public ActionResult Update(CommandUpdateDto updateDto)
        {

            var cmdFromRepo = _repo.GetById(updateDto.Id);
            if (cmdFromRepo == null)
                return NotFound();

            _mapper.Map(updateDto, cmdFromRepo);
            _repo.Update(cmdFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<CommandReadDto> Update(CommandUpdateDto updateDto)
        {

            var cmdFromRepo = _repo.GetById(updateDto.Id);
            if (cmdFromRepo == null)
                return NotFound();

            _mapper.Map(updateDto, cmdFromRepo);
            _repo.Update(cmdFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
    }

}