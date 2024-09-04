using CsvHelper;
using CsvHelper.Configuration;
using HYasinDemoApp.Components.Pages;
using HYasinDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace HYasinDemoApp.Services.DriverStandings
{
    public class DriverStandingsService : IDriverStandingsService
    {
        public async Task<List<DriverStanding>> GetDriverStandingsAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "HYasinDemoApp.Resources.dataset.driver_standings.csv";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException($"Resource '{resourceName}' not found.");
            }

            using StreamReader reader = new StreamReader(stream);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null, // Ignore missing fields
                HeaderValidated = null,   // Ignore header validation issues
                BadDataFound = context => { /* Handle bad data */ },
            };

            using var csv = new CsvReader(reader, config);

            try
            {
                var records = new List<DriverStanding>();
                await foreach (var record in csv.GetRecordsAsync<DriverStanding>())
                {
                    records.Add(record);
                }

                return records;
            }
            catch (CsvHelperException ex)
            {
                // Log or handle the exception as needed
                throw new Exception("An error occurred while reading the CSV file.", ex);
            }
        }
    }
}
