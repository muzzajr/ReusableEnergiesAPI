namespace RenewableEnergiesApi.Models
{
    /// <summary>
    /// Represents a response for a single bar chart.
    /// </summary>
    public class SingleBarChartResponse
    {
        /// <summary>
        /// The title of the chart.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// The labels for the chart.
        /// </summary>
        public required List<string> Labels { get; set; }

        /// <summary>
        /// The key for the data points.
        /// </summary>
        public required string Key { get; set; }

        /// <summary>
        /// The data points for the chart.
        /// </summary>
        public required List<double> DataPoints { get; set; }

        public SingleBarChartResponse() { }
    }
}
