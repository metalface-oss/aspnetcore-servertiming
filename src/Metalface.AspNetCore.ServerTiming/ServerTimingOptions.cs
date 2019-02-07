namespace Metalface.AspNetCore.ServerTiming
{
    public sealed class ServerTimingOptions
    {
        /// <summary>
        /// The description of metric of the total time for the request-response cycle on the server.
        /// See: https://www.w3.org/TR/server-timing/#description-attribute
        /// </summary>
        public string TotalDescription { get; set; } = "Total";

        /// <summary>
        /// Include the total time for the request-response cycle on the server.
        /// </summary>
        public bool TotalIncluded { get; set; } = true;

        /// <summary>
        /// The name of metric of the total time for the request-response cycle on the server.
        /// See: https://www.w3.org/TR/server-timing/#name-attribute
        /// </summary>
        public string TotalName { get; set; } = "total";
    }
}
