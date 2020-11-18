using Model.Contracts;
using System.Threading.Tasks;

namespace Model.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Paged<Player>> GetPlayersPaged(int page = 0, int pageSize = 25)
        {
            return await _playerRepository.GetPlayerPage(page, pageSize);
        }
    }
}
