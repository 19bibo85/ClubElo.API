using ClubElo.API.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClubElo.API.Clients
{
    public class ClubEloHttpClient : ClubEloLoader
    {
        public ClubEloHttpClient() : base()
        {

        }

        public async Task<ClubEloResult<ClubEloRank>> GetClubEloRanksByDateAsync(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));

            if (!Regex.IsMatch(input, @"\d{4}-\d{2}-\d{2}", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace))
                throw new FormatException($"{nameof(input)} must be in the format of YYYY-MM-DD i.e. 2024-04-20");

            return await Process<ClubEloRank>(input);
        }

        public async Task<ClubEloResult<ClubEloRank>> GetClubEloRanksByTeamAsync(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));

            return await Process<ClubEloRank>(input);
        }

        public async Task<ClubEloResult<ClubEloFixture>> GetClubEloFixturesAsync()
        {
            return await Process<ClubEloFixture>("Fixtures");
        }
    }
}
