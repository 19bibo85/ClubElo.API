using System.Collections.Generic;

namespace ClubElo.API.Models
{
    public class ClubEloResult<T> where T : class
    {
        public bool Success { get; set; } = true;

        public string Message { get; set; } = "OK";

        public List<T>? Data { get; set; }
    }
}
