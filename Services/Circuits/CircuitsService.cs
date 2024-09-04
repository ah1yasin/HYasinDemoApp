using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using HYasinDemoApp.Models;
using System.Reflection;

namespace HYasinDemoApp.Services.Circuits
{
    public class CircuitsService : ICircuitsService
    {
        public async Task<List<Circuit>> GetCircuitsAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "HYasinDemoApp.Resources.dataset.circuits.csv";

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
                var records = new List<Circuit>();
                await foreach (var record in csv.GetRecordsAsync<Circuit>())
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
