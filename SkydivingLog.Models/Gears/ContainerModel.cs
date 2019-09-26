using System.ComponentModel.DataAnnotations.Schema;

namespace SkydivingLog.Models.Gears
{
    [Table("[Gear].[ContainerModels]")]
    public class ContainerModel
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public int Name { get; set; }
    }
}
