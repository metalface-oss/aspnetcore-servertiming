using Metalface.AspNetCore.ServerTiming.Models;
using System.Collections.Generic;
using System.Linq;

namespace Metalface.AspNetCore.ServerTiming
{
    public sealed class ServerTimingRecorder : IServerTimingRecorder
    {
        private readonly List<Record> records;

        public ServerTimingRecorder() => this.records = new List<Record>();

        public void BeginRecord(string name, string description = default)
        {
            var records = this.records.Where(a => a.Name == name && !a.IsFinished());
            if (records.Any())
            {
                throw new System.ArgumentException("Recording is already started.", nameof(name));
            }

            this.records.Add(new Record(name, description));
        }

        public void EndRecord(string name)
        {
            var records = this.records.Where(a => a.Name == name && !a.IsFinished()).ToList();
            if (!records.Any())
            {
                throw new System.ArgumentException("Recording does not exist.", nameof(name));
            }

            records.Last().Finish();
        }

        public void EndRecord()
        {
            if (this.records.All(a => a.IsFinished()))
            {
                throw new System.Exception("No started recordings exist.");
            }

            this.records.Last().Finish();
        }

        public IReadOnlyList<Record> GetRecords() => this.records.AsReadOnly();

        public void Record(string name, double? duration = default, string description = default) =>
            this.records.Add(new Record(name, description, duration));
    }
}
