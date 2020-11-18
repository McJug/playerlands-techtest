using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contracts;
using testapi.DTO;

namespace testapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GetPlayerPageResponseDto>> GetPlayersPageAsync([FromQuery]GetPlayerPageRequestDto query)
        {
            var domainPlayers = await _playerService.GetPlayersPaged(query.Page);
            return _mapper.Map<GetPlayerPageResponseDto>(domainPlayers);
        }
    }
}