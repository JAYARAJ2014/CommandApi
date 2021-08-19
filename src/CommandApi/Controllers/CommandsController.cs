using System.Collections.Generic;
using AutoMapper;
using CommandApi.Data;
using CommandApi.Dtos;
using CommandApi.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var cmdFromRepo = _repo.GetById(id);
            if (cmdFromRepo == null)
                return NotFound();
            _repo.Delete(cmdFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdatePartial(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {

            var modelFromRepo = _repo.GetById(id);
            if (modelFromRepo == null)
                return NotFound();

            var cmdToPatch = _mapper.Map<CommandUpdateDto>(modelFromRepo);
            patchDoc.ApplyTo(cmdToPatch, ModelState);

            if (!TryValidateModel(cmdToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(cmdToPatch, modelFromRepo);
            _repo.Update(modelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
    }

}