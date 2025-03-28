using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RenewableEnergiesApi.Models
{
    public class RenewableEnergiesData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int TypeOfRenewableEnergy { get; set; }
        public double InstalledCapacityMW { get; set; }
        public double EnergyProductionMWh { get; set; }
        public double EnergyConsumptionMWh { get; set; }
        public double EnergyStorageCapacityMWh { get; set; }
        public double StorageEfficiencyPercentage { get; set; }
        public string? GridIntegrationLevel { get; set; }
        public double InitialInvestmentUSD { get; set; }
        public string? FundingSources { get; set; }
        public double FinancialIncentivesUSD { get; set; }
        public double GHGEmissionReductionTCO2e { get; set; }
        public double AirPollutionReductionIndex { get; set; }
        public double JobsCreated { get; set; }

        public RenewableEnergiesData() { }
    }

    public sealed class RenewableEnergiesDataMap : ClassMap<RenewableEnergiesData>
    {
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
