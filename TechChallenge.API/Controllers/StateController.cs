using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Core.DTO;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;

        public StateController(IStateService stateService, IMapper mapper)
        {
            _stateService = stateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStates()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<StateDto>>(await _stateService.GetAll()));
            }
            catch (Exception)
            {
                throw;
            }           
        }

        [HttpGet("{ddd:int}")]
        public async Task<ActionResult<StateDto>> GetStateByDDD(int ddd)
        {
            var state = await _stateService.GetByDDD(ddd);

            if (state is null)
            {
                return NotFound();
            }

            var stateDto = _mapper.Map<StateDto>(state);

            return Ok(stateDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStateById(Guid id)
        {
            var state = await _stateService.GetById(id);

            if (state is null)
            {
                return NotFound();
            }

            return Ok(state);
        }
    }
}
