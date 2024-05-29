using ClubElo.API.Clients;
using ClubElo.API.Models;
using System.Globalization;
using Xunit;

namespace ClubElo.API.Tests
{
    public class ClubEloHttpClientTests : IDisposable
    {
        #region Private Members

        private readonly ClubEloHttpClient Client;

        #endregion

        #region Constructor

        public ClubEloHttpClientTests()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IE");            

            Client = new ClubEloHttpClient();
        }

        #endregion
        

        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_ranks_by_a_null_date_Then_an_argument_null_exception_is_thrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetClubEloRanksByDateAsync(null));
        }


        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_ranks_by_an_invalid_date_Then_a_format_exception_is_thrown()
        {
            await Assert.ThrowsAsync<FormatException>(async () => await Client.GetClubEloRanksByDateAsync("wrong-format"));
        }


        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_ranks_by_a_null_team_Then_an_argument_null_exception_is_thrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetClubEloRanksByTeamAsync(null));
        }


        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_ranks_by_team_Then_a_list_of_elo_ranks_is_returned()
        {
            var result = await Client.GetClubEloRanksByTeamAsync("ManCity");

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.IsAssignableFrom<List<ClubEloRank>>(result.Data);
        }


        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_ranks_by_team_Then_values_returned_are_correct()
        {
            var result = await Client.GetClubEloRanksByTeamAsync("ManCity");

            var rank = result.Data[0];

            Assert.NotNull(rank);
            Assert.Equal("None", rank.Rank);
            Assert.Equal("Man City", rank.Club);
            Assert.Equal("ENG", rank.Country);
            Assert.Equal(2, rank.Level);
            Assert.Equal(1365.06604004m, rank.Elo);
            Assert.Equal(new DateTime(1946, 7, 7, 0, 0, 0, DateTimeKind.Utc), rank.From);
            Assert.Equal(new DateTime(1946, 9, 4, 0, 0, 0, DateTimeKind.Utc), rank.To);
        }


        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_ranks_by_date_Then_a_list_of_elo_ranks_is_returned()
        {
            var result = await Client.GetClubEloRanksByDateAsync("2024-01-01");

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.IsAssignableFrom<List<ClubEloRank>>(result.Data);
        }


        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_ranks_by_date_Then_values_returned_are_correct()
        {
            var result = await Client.GetClubEloRanksByDateAsync("2024-01-01");

            var rank = result.Data[0];

            Assert.NotNull(rank);
            Assert.Equal("1", rank.Rank);
            Assert.Equal("Man City", rank.Club);
            Assert.Equal("ENG", rank.Country);
            Assert.Equal(1, rank.Level);
            Assert.Equal(2042.03088379m, rank.Elo);
            Assert.Equal(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), rank.From);
            Assert.Equal(new DateTime(2024, 1, 13, 0, 0, 0, DateTimeKind.Utc), rank.To);
        }


        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_fixtures_Then_a_list_of_elo_fixtures_is_returned()
        {
            var result = await Client.GetClubEloFixturesAsync();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.IsAssignableFrom<List<ClubEloFixture>>(result.Data);
        }

        [Fact]
        public async Task Given_an_http_client_When_requesting_elo_fixtures_Then_values_returned_are_correct()
        {
            var result = await Client.GetClubEloFixturesAsync();

            var fixture = result.Data[0];

            Assert.NotNull(fixture);
            Assert.NotNull(fixture.Date);
            Assert.NotNull(fixture.Country);
            Assert.NotNull(fixture.Home);
            Assert.NotNull(fixture.Away);
            Assert.NotNull(fixture.GDLtM5);
            Assert.NotNull(fixture.GDEqM5);
            Assert.NotNull(fixture.GDEqM4);
            Assert.NotNull(fixture.GDEqM3);
            Assert.NotNull(fixture.GDEqM2);
            Assert.NotNull(fixture.GDEqM1);
            Assert.NotNull(fixture.GDEq0);
            Assert.NotNull(fixture.GDEq1);
            Assert.NotNull(fixture.GDEq2);
            Assert.NotNull(fixture.GDEq3);
            Assert.NotNull(fixture.GDEq4);
            Assert.NotNull(fixture.GDEq5);
            Assert.NotNull(fixture.GDGt5);
            Assert.NotNull(fixture.R00);
            Assert.NotNull(fixture.R01);
            Assert.NotNull(fixture.R10);
            Assert.NotNull(fixture.R11);
            Assert.NotNull(fixture.R02);
            Assert.NotNull(fixture.R20);
            Assert.NotNull(fixture.R12);
            Assert.NotNull(fixture.R21);
            Assert.NotNull(fixture.R22);
            Assert.NotNull(fixture.R03);
            Assert.NotNull(fixture.R30);
            Assert.NotNull(fixture.R13);
            Assert.NotNull(fixture.R31);
            Assert.NotNull(fixture.R23);
            Assert.NotNull(fixture.R32);
            Assert.NotNull(fixture.R33);
            Assert.NotNull(fixture.R40);
            Assert.NotNull(fixture.R04);
            Assert.NotNull(fixture.R41);
            Assert.NotNull(fixture.R14);
            Assert.NotNull(fixture.R42);
            Assert.NotNull(fixture.R24);
            Assert.NotNull(fixture.R50);
            Assert.NotNull(fixture.R05);
            Assert.NotNull(fixture.R51);
            Assert.NotNull(fixture.R15);
            Assert.NotNull(fixture.R60);
            Assert.NotNull(fixture.R06);
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
