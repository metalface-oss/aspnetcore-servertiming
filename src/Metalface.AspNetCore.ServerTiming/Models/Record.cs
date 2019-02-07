using System.Diagnostics;

namespace Metalface.AspNetCore.ServerTiming.Models
{
    public sealed class Record
    {
        private readonly double? duration;
        private readonly Stopwatch stopwatch;

        public Record(string name, string description, double? duration = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("Name is not valid.", nameof(name));
            }

            this.Description = description?.Trim();
            this.Name = name.Trim();

            this.duration = duration;

            if (!duration.HasValue)
            {
                this.stopwatch = Stopwatch.StartNew();
            }
        }

        public string Description { get; }

        public double? Duration => this.duration ?? this.stopwatch?.ElapsedMilliseconds;

        public string Name { get; }

        public void Finish()
        {
            if (this.IsFinished())
            {
                return;
            }

            this.stopwatch.Stop();
        }

        public bool IsFinished() => this.stopwatch?.IsRunning != true;
    }
}
