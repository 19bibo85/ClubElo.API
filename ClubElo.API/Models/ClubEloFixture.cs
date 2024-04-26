using ClubElo.API.Attributes;
using System;

namespace ClubElo.API.Models
{
    // api.clubelo.com/Fixtures
    public class ClubEloFixture
    {
        [ColumnName("Date")]
        private string? DateRaw { get; set; }

        public DateTime? Date => DateTime.TryParse(DateRaw?.Trim(), out var value) ? (DateTime?) value : null;


        [ColumnName("Country")]
        private string? CountryRaw { get; set; }

        public string? Country => CountryRaw?.Trim();


        [ColumnName("Home")]
        private string? HomeRaw { get; set; }

        public string? Home => HomeRaw?.Trim();


        [ColumnName("Away")]
        private string? AwayRaw { get; set; }

        public string? Away => AwayRaw?.Trim();


        [ColumnName("GD<-5")]
        private string? GDLtM5Raw { get; set; }

        public decimal? GDLtM5 => decimal.TryParse(GDLtM5Raw?.Trim(), out var value) ? (decimal?) value : null;


        [ColumnName("GD=-5")]
        private string? GDEqM5Raw { get; set; }

        public decimal? GDEqM5 => decimal.TryParse(GDEqM5Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=-4")]
        private string? GDEqM4Raw { get; set; }

        public decimal? GDEqM4 => decimal.TryParse(GDEqM4Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=-3")]
        private string? GDEqM3Raw { get; set; }

        public decimal? GDEqM3 => decimal.TryParse(GDEqM3Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=-2")]
        private string? GDEqM2Raw { get; set; }

        public decimal? GDEqM2 => decimal.TryParse(GDEqM2Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=-1")]
        private string? GDEqM1Raw { get; set; }

        public decimal? GDEqM1 => decimal.TryParse(GDEqM1Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=0")]
        private string? GDEq0Raw { get; set; }

        public decimal? GDEq0 => decimal.TryParse(GDEq0Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=1")]
        private string? GDEq1Raw { get; set; }

        public decimal? GDEq1 => decimal.TryParse(GDEq1Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=2")]
        private string? GDEq2Raw { get; set; }

        public decimal? GDEq2 => decimal.TryParse(GDEq2Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=3")]
        private string? GDEq3Raw { get; set; }

        public decimal? GDEq3 => decimal.TryParse(GDEq3Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=4")]
        private string? GDEq4Raw { get; set; }

        public decimal? GDEq4 => decimal.TryParse(GDEq4Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD=5")]
        private string? GDEq5Raw { get; set; }

        public decimal? GDEq5 => decimal.TryParse(GDEq5Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("GD>5")]
        private string? GDGt5Raw { get; set; }

        public decimal? GDGt5 => decimal.TryParse(GDGt5Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:0-0")]
        private string? R00Raw { get; set; }

        public decimal? R00 => decimal.TryParse(R00Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:0-1")]
        private string? R01Raw { get; set; }

        public decimal? R01 => decimal.TryParse(R01Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:1-0")]
        private string? R10Raw { get; set; }

        public decimal? R10 => decimal.TryParse(R10Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:1-1")]
        private string? R11Raw { get; set; }

        public decimal? R11 => decimal.TryParse(R11Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:0-2")]
        private string? R02Raw { get; set; }

        public decimal? R02 => decimal.TryParse(R02Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:2-0")]
        private string? R20Raw { get; set; }

        public decimal? R20 => decimal.TryParse(R20Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:1-2")]
        private string? R12Raw { get; set; }

        public decimal? R12 => decimal.TryParse(R12Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:2-1")]
        private string? R21Raw { get; set; }

        public decimal? R21 => decimal.TryParse(R21Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:2-2")]
        private string? R22Raw { get; set; }

        public decimal? R22 => decimal.TryParse(R22Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:0-3")]
        private string? R03Raw { get; set; }

        public decimal? R03 => decimal.TryParse(R03Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:3-0")]
        private string? R30Raw { get; set; }

        public decimal? R30 => decimal.TryParse(R30Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:1-3")]
        private string? R13Raw { get; set; }

        public decimal? R13 => decimal.TryParse(R13Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:3-1")]
        private string? R31Raw { get; set; }

        public decimal? R31 => decimal.TryParse(R31Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:2-3")]
        private string? R23Raw { get; set; }

        public decimal? R23 => decimal.TryParse(R23Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:3-2")]
        private string? R32Raw { get; set; }

        public decimal? R32 => decimal.TryParse(R32Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:3-3")]
        private string? R33Raw { get; set; }

        public decimal? R33 => decimal.TryParse(R33Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:0-4")]
        private string? R04Raw { get; set; }

        public decimal? R04 => decimal.TryParse(R04Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:4-0")]
        private string? R40Raw { get; set; }

        public decimal? R40 => decimal.TryParse(R40Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:1-4")]
        private string? R14Raw { get; set; }

        public decimal? R14 => decimal.TryParse(R14Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:4-1")]
        private string? R41Raw { get; set; }

        public decimal? R41 => decimal.TryParse(R41Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:2-4")]
        private string? R24Raw { get; set; }

        public decimal? R24 => decimal.TryParse(R24Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:4-2")]
        private string? R42Raw { get; set; }

        public decimal? R42 => decimal.TryParse(R42Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:0-5")]
        private string? R05Raw { get; set; }

        public decimal? R05 => decimal.TryParse(R05Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:5-0")]
        private string? R50Raw { get; set; }

        public decimal? R50 => decimal.TryParse(R50Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:1-5")]
        private string? R15Raw { get; set; }

        public decimal? R15 => decimal.TryParse(R15Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:5-1")]
        private string? R51Raw { get; set; }

        public decimal? R51 => decimal.TryParse(R51Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:0-6")]
        private string? R06Raw { get; set; }

        public decimal? R06 => decimal.TryParse(R06Raw?.Trim(), out var value) ? (decimal?)value : null;


        [ColumnName("R:6-0")]
        private string? R60Raw { get; set; }

        public decimal? R60 => decimal.TryParse(R60Raw?.Trim(), out var value) ? (decimal?)value : null;
    }
}
