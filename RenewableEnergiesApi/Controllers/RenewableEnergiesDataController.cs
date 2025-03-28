using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RenewableEnergiesApi.DB;
using RenewableEnergiesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RenewableEnergiesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RenewableEnergiesDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RenewableEnergiesDataController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-top-ten-records")]
        public async Task<IEnumerable<RenewableEnergiesData>> GetTopTen()
        {
            return await _context.Records.Take(10).ToListAsync();
        }

        [HttpGet("average-installed-capacity/{energyType}")]
        public async Task<GenericResponse> GetAverageInstalledCapacity([FromRoute] string energyType)
        {
            Enum.TryParse(energyType, out TypesOfRenewableEnergy typeOfRenewableEnergy);

            var type1Records = await _context.Records
                .Where(record => record.TypeOfRenewableEnergy == (int)typeOfRenewableEnergy)
                .ToListAsync();

            // Calculate the average InstalledCapacityMW for the filtered records
            var averageInstalledCapacity = type1Records
                .Average(record => record.InstalledCapacityMW);

            return new GenericResponse
            {
                title = energyType,
                dataPoints = [averageInstalledCapacity]
            };
        }

        [HttpGet("all-average-installed-capacity")]
        public async Task<List<GenericResponse>> GettAllEnergyTypeInstalledCapacity()
        {
            var allEnergyTypes = Enum.GetValues(typeof(TypesOfRenewableEnergy))
                .Cast<TypesOfRenewableEnergy>()
                .ToList();
            var allAverageInstalledCapacity = new List<GenericResponse>();
            foreach (var energyType in allEnergyTypes)
            {
                var typeRecords = await _context.Records
                    .Where(record => record.TypeOfRenewableEnergy == (int)energyType)
                    .ToListAsync();
                var averageInstalledCapacity = typeRecords
                    .Average(record => record.InstalledCapacityMW);
                allAverageInstalledCapacity.Add(new GenericResponse
                {
                    title = energyType.ToString(),
                    dataPoints = [averageInstalledCapacity]
                });
            }
            return allAverageInstalledCapacity;
        }

        public class GenericResponse
        {
            public required string title { get; set; }
            public required double[] dataPoints { get; set; }

            public GenericResponse() { }
        }
    }

}
