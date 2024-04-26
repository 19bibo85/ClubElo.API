using ClubElo.API.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ClubElo.API.Parsers
{
    internal class ClubEloParser<TOutput> where TOutput : class
    {
        private const char Separator = ',';

        private readonly Dictionary<string, string> ClubEloEntryMapping = new Dictionary<string, string>();

        private ClubEloParser()
        {
            var properties = Activator.CreateInstance(typeof(TOutput))
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var property in properties)
            {
                if (string.IsNullOrWhiteSpace(property.Name))
                    continue;

                var columnNames = property.GetCustomAttribute<ColumnNameAttribute>()?.Names?.Split(Separator) ?? new string[1] { property.Name };
                foreach (var columnName in columnNames)
                {
                    if (ClubEloEntryMapping.ContainsKey(columnName))
                        continue;

                    ClubEloEntryMapping.Add(columnName, property.Name);
                }
            }
        }

        internal static ClubEloParser<TOutput> Create() => new ClubEloParser<TOutput>();

        internal async Task<List<TOutput>> Parse(StreamReader stream)
        {
            stream.BaseStream.Position = 0;

            var entries = new List<TOutput>();

            Dictionary<int, string> clubEloEntryIndexing = new Dictionary<int, string>();

            int i = 0;
            while (!stream.EndOfStream)
            {
                try
                {
                    var line = await stream.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // header
                    if (i == 0)
                    {
                        var headerColumns = line.Split(Separator);
                        for (int j = 0; j < headerColumns.Length; j++)
                        {
                            if (string.IsNullOrWhiteSpace(headerColumns[j]))
                                continue;

                            if (!ClubEloEntryMapping.ContainsKey(headerColumns[j].Trim()))
                                continue;

                            clubEloEntryIndexing.Add(j, headerColumns[j]);
                        }
                        continue;
                    }

                    // no columns in the header
                    if (clubEloEntryIndexing.Count == 0)
                        continue;

                    // data
                    var entry = CreateClubEloEntry(line, clubEloEntryIndexing);
                    if (entry == null)
                        continue;

                    entries.Add(entry);
                }
                finally
                {
                    i++;
                }
            }

            return entries;
        }

        private TOutput? CreateClubEloEntry(string line, Dictionary<int, string> clubEloEntryIndexing)
        {
            TOutput? entry = null;

            var dataColumns = line.Split(Separator);
            for (int j = 0; j < dataColumns.Length; j++)
            {
                try
                {
                    if (!clubEloEntryIndexing.ContainsKey(j))
                        continue;

                    var headerColumn = clubEloEntryIndexing[j];
                    if (!ClubEloEntryMapping.ContainsKey(headerColumn))
                        continue;

                    var propertyName = ClubEloEntryMapping[headerColumn];
                    if (string.IsNullOrWhiteSpace(propertyName))
                        continue;

                    if (entry == null)
                        entry = (TOutput) Activator.CreateInstance(typeof(TOutput));

                    entry
                        .GetType()
                        .GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic)
                        .SetValue(entry, dataColumns[j]);
                }
                catch
                {
                    entry = null;
                }
            }

            return entry;
        }
    }
}
