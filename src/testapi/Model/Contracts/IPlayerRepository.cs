using System.Threading.Tasks;

namespace Model.Contracts
{
    public interface IPlayerRepository
    {
        Task<Paged<Player>> GetPlayerPage(int page = 0, int pageSize = 25);
    }
}
