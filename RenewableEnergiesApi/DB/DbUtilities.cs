using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using RenewableEnergiesApi.Models;

namespace RenewableEnergiesApi.DB
{
    public class DbUtilities
    {
        /// <summary>
        /// Creates the database and populates it with data from a CSV file.
        /// </summary>
        public void CreateDatabase()
        {
            string csvFilePath = ".\\DB\\energy_dataset_.csv";

            using var context = new AppDbContext();
            if (context.Database.EnsureCreated())
            {
                // Read the CSV file
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true }))
                {
                    csv.Context.RegisterClassMap<RenewableEnergiesDataMap>();
                    var records = csv.GetRecords<RenewableEnergiesData>().ToList();
                    context.Records.AddRange(records); // Add records to the database
                    context.SaveChanges();
                }

                Console.WriteLine("CSV data has been successfully inserted into the SQLite database.");
            }
        }
    }
    
}

