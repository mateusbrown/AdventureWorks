using System;
using System.Collections.Generic;

namespace WebApi.Repositories.Models
{
    public partial class BillOfMaterials
    {
        public int? ProductAssemblyId { get; set; }
        public int ComponentId { get; set; }
        public string Name { get; set; } = null!;
        public decimal PerAssemblyQty { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public short Bomlevel { get; set; }
        public int RecursionLevel { get; set;}
    }
}