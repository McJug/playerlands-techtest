using System.Threading.Tasks;

namespace Model.Contracts
{
    public interface IPlayerService
    {
        Task<Paged<Player>> GetPlayersPaged(int page = 0, int pageSize = 25);
    }
}
