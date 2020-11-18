using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Repository.Test
{
    public class PlayerRepositoryTests
    {
        private readonly DbContextOptions<PlayerDatabaseContext> _inMemoryDbOptions;

        public PlayerRepositoryTests()
        {
            _inMemoryDbOptions = new DbContextOptionsBuilder<PlayerDatabaseContext>()
                .UseInMemoryDatabase("PlayerRepositoryTests")
                .Options;
        }

        [Fact]
        public async Task DatabaseHasSeedRecords()
        {
            using (var ctx = new PlayerDatabaseContext(_inMemoryDbOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var countPlayers = await ctx.Players.CountAsync();
                Assert.Equal(3, countPlayers);

                ctx.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task GetPlayerPage_ReturnsSeedData()
        {
            using (var ctx = new PlayerDatabaseContext(_inMemoryDbOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var playerRepository = new PlayerRepository(ctx);

                var pagedSeed = await playerRepository.GetPlayerPage();
                Assert.Equal(3, pagedSeed.TotalRecords);
                Assert.Equal(25, pagedSeed.PageSize);
                Assert.Equal(0, pagedSeed.Page);
                Assert.Equal(3, pagedSeed.Data.Length);

                ctx.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task GetPlayerPage_PageOverflow_RetrunsEmptyPage()
        {
            using (var ctx = new PlayerDatabaseContext(_inMemoryDbOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var playerRepository = new PlayerRepository(ctx);

                var pagedSeed = await playerRepository.GetPlayerPage(1);
                Assert.Equal(3, pagedSeed.TotalRecords);
                Assert.Equal(25, pagedSeed.PageSize);
                Assert.Equal(1, pagedSeed.Page);
                Assert.Empty(pagedSeed.Data);

                ctx.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task GetPlayerPage_WithOverrides_ReturnsCorrectPageData()
        {
            using (var ctx = new PlayerDatabaseContext(_inMemoryDbOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var playerRepository = new PlayerRepository(ctx);

                var pagedSeed = await playerRepository.GetPlayerPage(0, 50);
                Assert.Equal(3, pagedSeed.TotalRecords);
                Assert.Equal(50, pagedSeed.PageSize);
                Assert.Equal(0, pagedSeed.Page);
                Assert.Equal(3, pagedSeed.Data.Length);

                ctx.Database.EnsureDeleted();
            }
        }
    }
}
