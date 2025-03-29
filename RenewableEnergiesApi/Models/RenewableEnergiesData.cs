using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RenewableEnergiesApi.Models
{
    public class RenewableEnergiesData
    {
        /// <summary>
        /// Gets or sets the unique identifier for the record.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the type of renewable energy.
        /// </summary>
        public int TypeOfRenewableEnergy { get; set; }

        /// <summary>
        /// Gets or sets the installed capacity in megawatts (MW).
        /// </summary>
        public double InstalledCapacityMW { get; set; }

        /// <summary>
        /// Gets or sets the energy production in megawatt-hours (MWh).
        /// </summary>
        public double EnergyProductionMWh { get; set; }

        /// <summary>
        /// Gets or sets the energy consumption in megawatt-hours (MWh).
        /// </summary>
        public double EnergyConsumptionMWh { get; set; }

        /// <summary>
        /// Gets or sets the energy storage capacity in megawatt-hours (MWh).
        /// </summary>
        public double EnergyStorageCapacityMWh { get; set; }

        /// <summary>
        /// Gets or sets the storage efficiency percentage.
        /// </summary>
        public double StorageEfficiencyPercentage { get; set; }

        /// <summary>
        /// Gets or sets the grid integration level.
        /// </summary>
        public string? GridIntegrationLevel { get; set; }

        /// <summary>
        /// Gets or sets the initial investment in USD.
        /// </summary>
        public double InitialInvestmentUSD { get; set; }

        /// <summary>
        /// Gets or sets the funding sources.
        /// </summary>
        public string? FundingSources { get; set; }

        /// <summary>
        /// Gets or sets the financial incentives in USD.
        /// </summary>
        public double FinancialIncentivesUSD { get; set; }

        /// <summary>
        /// Gets or sets the greenhouse gas (GHG) emission reduction in tons of CO2 equivalent (tCO2e).
        /// </summary>
        public double GHGEmissionReductionTCO2e { get; set; }

        /// <summary>
        /// Gets or sets the air pollution reduction index.
        /// </summary>
        public double AirPollutionReductionIndex { get; set; }

        /// <summary>
        /// Gets or sets the number of jobs created.
        /// </summary>
        public double JobsCreated { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenewableEnergiesData"/> class.
        /// </summary>
        public RenewableEnergiesData() { }
    }

    /// <summary>
    /// Class map for CSV mapping of <see cref="RenewableEnergiesData"/>.
    /// </summary>
    public sealed class RenewableEnergiesDataMap : ClassMap<RenewableEnergiesData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenewableEnergiesDataMap"/> class.
        /// </summary>
        public RenewableEnergiesDataMap()
        {
            Map(m => m.TypeOfRenewableEnergy).Name("Type_of_Renewable_Energy");
            Map(m => m.InstalledCapacityMW).Name("Installed_Capacity_MW");
            Map(m => m.EnergyProductionMWh).Name("Energy_Production_MWh");
            Map(m => m.EnergyConsumptionMWh).Name("Energy_Consumption_MWh");
            Map(m => m.EnergyStorageCapacityMWh).Name("Energy_Storage_Capacity_MWh");
            Map(m => m.StorageEfficiencyPercentage).Name("Storage_Efficiency_Percentage");
            Map(m => m.GridIntegrationLevel).Name("Grid_Integration_Level");
            Map(m => m.InitialInvestmentUSD).Name("Initial_Investment_USD");
            Map(m => m.FundingSources).Name("Funding_Sources");
            Map(m => m.FinancialIncentivesUSD).Name("Financial_Incentives_USD");
            Map(m => m.GHGEmissionReductionTCO2e).Name("GHG_Emission_Reduction_tCO2e");
            Map(m => m.AirPollutionReductionIndex).Name("Air_Pollution_Reduction_Index");
            Map(m => m.JobsCreated).Name("Jobs_Created");
        }
    }
}


