using System;

namespace Dotnet.CosmosDB.Demo.Entities
{
    public class Employer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PositionStarted { get; set; }
        public DateTime? PositionEnded { get; set; }

    }
}
