using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RenewableEnergiesApi.DB;
using RenewableEnergiesApi.Models;


namespace RenewableEnergiesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RenewableEnergiesDataController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<RenewableEnergiesDataController> _logger;

        public RenewableEnergiesDataController(AppDbContext context, ILogger<RenewableEnergiesDataController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets the top ten records from the database.
        /// </summary>
        /// <returns>A list of the top ten RenewableEnergiesData records.</returns>
        [HttpGet("get-top-ten-records")]
        public async Task<IEnumerable<RenewableEnergiesData>> GetTopTen()
        {
            _logger.LogInformation("Fetching top ten records.");

            return await _context.Records.Take(10).ToListAsync();
        }

        /// <summary>
        /// Gets the average installed capacity for a specific type of renewable energy.
        /// </summary>
        /// <param name="energyType">The type of renewable energy.</param>
        /// <returns>A SingleBarResponse containing the average installed capacity.</returns>
        [HttpGet("average-installed-capacity/{energyType}")]
        public async Task<SingleBarChartResponse> GetAverageInstalledCapacity([FromRoute] string energyType)
        {
            _logger.LogInformation($"Calculating average installed capacity for {energyType}.");

            _ = Enum.TryParse(energyType, out TypesOfRenewableEnergy typeOfRenewableEnergy);

            var type1Records = await _context.Records
                .Where(record => record.TypeOfRenewableEnergy == (int)typeOfRenewableEnergy)
                .ToListAsync();

            // Calculate the average InstalledCapacityMW for the filtered records
            var averageInstalledCapacity = type1Records
                .Average(record => record.InstalledCapacityMW);

            return new SingleBarChartResponse
            {
                Title = energyType,
                Labels = [energyType],
                Key = "Installed Capacity (MW)",
                DataPoints = [averageInstalledCapacity]
            };
        }

        /// <summary>
        /// Gets the average installed capacity for all types of renewable energy.
        /// </summary>
        /// <returns>A SingleBarResponse containing the average installed capacity for all types.</returns>
        [HttpGet("all-average-installed-capacity")]
        public async Task<SingleBarChartResponse> GettAllEnergyTypeInstalledCapacity()
        {
            _logger.LogInformation("Calculating average installed capacity for all energy types.");

            var allEnergyTypes = Enum.GetValues(typeof(TypesOfRenewableEnergy))
                .Cast<TypesOfRenewableEnergy>()
                .ToList();
            var allAverageInstalledCapacity = new List<double>();

            foreach (var energyType in allEnergyTypes)
            {
                var typeRecords = await _context.Records
                    .Where(record => record.TypeOfRenewableEnergy == (int)energyType)
                    .ToListAsync();
                var averageInstalledCapacity = typeRecords
                    .Average(record => record.InstalledCapacityMW);

                allAverageInstalledCapacity.Add(averageInstalledCapacity);
            }

            var response = new SingleBarChartResponse
            {
                Title = "Average Installed Capacity of Different Types of Renewable Energy",
                Key = "Installed Capacity (MW)",
                Labels = [.. allEnergyTypes.Select(energyType => energyType.ToString())],
                DataPoints = allAverageInstalledCapacity
            };

            return response;
        }

        /// <summary>
        /// Gets the average initial investment and GHG emission reduction for all types of renewable energy.
        /// </summary>
        /// <returns>A MultiBarResponse containing the average initial investment and GHG emission reduction for all types.</returns>
        [HttpGet("investment-and-emission-reduction")]
        public async Task<MultiBarChartResponse> GettAllEnergyTypeInvestmentAndEmissionReduction()
        {
            _logger.LogInformation("Calculating average initial investment and GHG emission reduction for all energy types.");

            var allEnergyTypes = Enum.GetValues(typeof(TypesOfRenewableEnergy))
                .Cast<TypesOfRenewableEnergy>()
                .ToList();

            var allAverageInitialInvestment = new List<double>();
            var allAverageEmissionReduction = new List<double>();

            foreach (var energyType in allEnergyTypes)
            {
                var typeRecords = await _context.Records
                    .Where(record => record.TypeOfRenewableEnergy == (int)energyType)
                    .ToListAsync();

                var averageInitialInvestmant = typeRecords
                    .Average(record => record.InitialInvestmentUSD);

                var averageEmissionReduction = typeRecords
                    .Average(record => record.AirPollutionReductionIndex);

                allAverageInitialInvestment.Add(averageInitialInvestmant);
                allAverageEmissionReduction.Add(averageEmissionReduction);
            }

            var response = new MultiBarChartResponse
            {
                Title = "Average Initial Investment compared to the Average GHG Emission Reduction",
                Labels = [.. allEnergyTypes.Select(energyType => energyType.ToString())],
                Keys = ["Initial Investment USD", "GHG Emission Reduction tCO2e"],
                DataPoints = [allAverageInitialInvestment, allAverageEmissionReduction]
            };

            return response;
        }

        /// <summary>
        /// Gets a paginated list of records, optionally filtered by energy type and sorted by a specified field.
        /// </summary>
        /// <param name="pageNumber">The page number (default is 1).</param>
        /// <param name="pageSize">The number of records per page (default is 10).</param>
        /// <param name="energyType">The type of renewable energy to filter by (optional).</param>
        /// <param name="sortBy">The field to sort by (optional).</param>
        /// <returns>A paginated list of RenewableEnergiesData records.</returns>
        [HttpGet("get-records")]
        public async Task<IEnumerable<RenewableEnergiesData>> GetRecords(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? energyType = null,
            [FromQuery] string? sortBy = null)
        {
            _logger.LogInformation($"Fetching records for page {pageNumber} with page size {pageSize}. Using EnergyType {energyType} and sortBy value {sortBy}");

            var query = _context.Records.AsQueryable();

            if (!string.IsNullOrEmpty(energyType))
            {
                _ = Enum.TryParse(energyType, out TypesOfRenewableEnergy typeOfRenewableEnergy);
                query = query.Where(record => record.TypeOfRenewableEnergy == (int)typeOfRenewableEnergy);
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortBy switch
                {
                    "InstalledCapacity" => query.OrderByDescending(record => record.InstalledCapacityMW),
                    "EnergyProduction" => query.OrderByDescending(record => record.EnergyProductionMWh),
                    _ => query
                };
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
