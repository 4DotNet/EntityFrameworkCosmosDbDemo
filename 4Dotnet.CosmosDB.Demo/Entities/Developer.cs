using System;
using System.Collections.Generic;

namespace Dotnet.CosmosDB.Demo.Entities
{
    public class Developer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Employer CurrentEmployer { get; set; }
        public List<Employer> PreviousEmployers { get; set; }
    }
}
