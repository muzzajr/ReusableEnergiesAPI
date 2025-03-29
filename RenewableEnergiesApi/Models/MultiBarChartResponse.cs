namespace RenewableEnergiesApi.Models
{
    /// <summary>
    /// Represents a response for a multi-bar chart.
    /// </summary>
    public class MultiBarChartResponse
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
        /// The keys for the data points.
        /// </summary>
        public required List<string> Keys { get; set; }

        /// <summary>
        /// The data points for the chart.
        /// </summary>
        public required List<List<double>> DataPoints { get; set; }

        public MultiBarChartResponse() { }
    }
}
