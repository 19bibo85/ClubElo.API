using ClubElo.API.Attributes;
using System;

namespace ClubElo.API.Models
{
    // api.clubelo.com/2024-04-25
    // api.clubelo.com/ManCity
    public class ClubEloRank
    {
        [ColumnName("Rank")]
        private string? RankRaw { get; set; }

        public string? Rank => RankRaw?.Trim();


        [ColumnName("Club")]
        private string? ClubRaw { get; set; }

        public string? Club => ClubRaw?.Trim();


        [ColumnName("Country")]
        private string? CountryRaw { get; set; }

        public string? Country => CountryRaw?.Trim();


        [ColumnName("Level")]
        private string? LevelRaw { get; set; }

        public int? Level => int.TryParse(LevelRaw?.Trim(), out var value) ? (int?)value : null;


        [ColumnName("Elo")]
        private string? EloRaw { get; set; }

        public decimal? Elo => decimal.TryParse(EloRaw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("From")]
        private string? FromRaw { get; set; }

        public DateTime? From => DateTime.TryParse(FromRaw?.Trim(), out var value) ? (DateTime?)value : null;


        [ColumnName("To")]
        private string? ToRaw { get; set; }

        public DateTime? To => DateTime.TryParse(ToRaw?.Trim(), out var value) ? (DateTime?)value : null;
    }
}
