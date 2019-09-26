using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkydivingLog.Models.Gears
{
    [Table("[Gear].[Containers]")]
    public class Container
    {
        public int Id { get; set; }
        public int ContainerModelId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufacturedDate { get; set; }
    }
}
