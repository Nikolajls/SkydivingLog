using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Gears
{
    [Table("[Gear].[Canopies]")]
    public class Canopy
    {
        public int Id { get; set; }
        public int CanopyModelId { get; set; }
        public int SquareFoot { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufacturedDate { get; set; }
    }
}
