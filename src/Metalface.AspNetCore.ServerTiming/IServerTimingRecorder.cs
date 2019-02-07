using Metalface.AspNetCore.ServerTiming.Models;
using System.Collections.Generic;

namespace Metalface.AspNetCore.ServerTiming
{
    public interface IServerTimingRecorder
    {
        /// <summary>
        /// Begins recording metric.
        /// </summary>
        /// <param name="name">Metric name</param>
        /// <param name="description">Metric description</param>
        void BeginRecord(string name, string description = default);

        /// <summary>
        /// Ends recording specific metric.
        /// </summary>
        /// <param name="name">Metric name</param>
        void EndRecord(string name);

        /// <summary>
        /// Ends recording the last started metric.
        /// </summary>
        void EndRecord();

        /// <summary>
        /// Returns the list of records (for debugging purposes).
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Record> GetRecords();

        /// <summary>
        /// Records a metric when measurement is not required.
        /// </summary>
        /// <param name="name">Metric name</param>
        /// <param name="duration">Duration in milliseconds</param>
        /// <param name="description">Metric description</param>
        void Record(string name, double? duration = default, string description = default);
    }
}
