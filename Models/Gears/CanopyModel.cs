using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Gears
{
    [Table("[Gear].[CanopyModels]")]
    public class CanopyModel
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
    }
}
