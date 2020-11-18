using Model.Contracts;
using Model.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Model.Test.Services
{
    public class PlayerServiceTests
    {
        private readonly PlayerService _playerService;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;

        public PlayerServiceTests()
        {
            _mockPlayerRepository = new Mock<IPlayerRepository>();
            _mockPlayerRepository.Setup(r => r.GetPlayerPage(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int page, int pageSize) =>
                {
                    return Task.FromResult(new Paged<Player>
                    {
                        TotalRecords = 0,
                        Data = new Player[0],
                        Page = page,
                        PageSize = pageSize
                    });
                });

            _playerService = new PlayerService(_mockPlayerRepository.Object);
        }
        
        [Fact]
        public async Task GetsPageZero_WithNoOverloads()
        {
            var page = await _playerService.GetPlayersPaged();
            Assert.Equal(0, page.Page);
        }

        [Fact]
        public async Task GetsPageSize25_WithNoOverrides()
        {
            var page = await _playerService.GetPlayersPaged();
            Assert.Equal(25, page.PageSize);
        }

        [Fact]
        public async Task CallsPlayerRepositoryOnce()
        {
            var page = await _playerService.GetPlayersPaged();
            _mockPlayerRepository.Verify(s => s.GetPlayerPage(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
