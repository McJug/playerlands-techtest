using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerDatabaseContext _playerDatabaseContext;

        public PlayerRepository(PlayerDatabaseContext playerDatabaseContext)
        {
            _playerDatabaseContext = playerDatabaseContext;
        }

        public async Task<Paged<Player>> GetPlayerPage(int page = 0, int pageSize = 25)
        {
            return new Paged<Player>
            {
                Data = await _playerDatabaseContext
                        .Players
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToArrayAsync(),
                Page = page,
                PageSize = pageSize,
                TotalRecords = await _playerDatabaseContext.Players.CountAsync()
            };
        }
    }
}
