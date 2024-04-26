using ClubElo.API.Models;
using ClubElo.API.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClubElo.API.Clients
{
    public abstract class ClubEloLoader : IDisposable
    {
        #region Private Members

        private readonly HttpClient Client;

        #endregion

        #region Constructor

        protected ClubEloLoader()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.EloEndpoint);
        }

        #endregion

        #region Process

        internal async Task<ClubEloResult<TOutput>> Process<TOutput>(string endpoint) where TOutput : class
        {
            var result = new ClubEloResult<TOutput> { Data = new List<TOutput>() };

            var errors = new StringBuilder();

            try
            {
                var entries = await LoadClubEloEntries<TOutput>(endpoint);
                if (entries.Any())
                    result.Data = entries;
            }
            catch (Exception ex)
            {
                errors.AppendLine(ex.ToString());
                result.Success = false;
            }

            if (errors.Length > 0)
                result.Message = errors.ToString();

            return result;
        }

        private async Task<List<TOutput>> LoadClubEloEntries<TOutput>(string endpoint) where TOutput : class
        {
            using HttpResponseMessage response = await Client.GetAsync($"/{endpoint}");
            using Stream stream = await response.Content.ReadAsStreamAsync();
            using StreamReader reader = new StreamReader(stream);

            return await ClubEloParser<TOutput>.Create().Parse(reader);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
                Client.Dispose();
            }
        }

        #endregion
    }
}
