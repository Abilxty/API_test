using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Models;
using Commander.Data;
using AutoMapper;
using Commander.Dtos;

namespace Commander.Controllers{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase{
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
          _repository = repository;
          _mapper = mapper;
        }
        
        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAppCommands(){
            
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name ="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id){

            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null){

            return Ok(_mapper.Map<CommandReadDto>(commandItem));

            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto){
            
            if(commandCreateDto == null){
                throw new System.ArgumentNullException();
            }
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }
    }
}