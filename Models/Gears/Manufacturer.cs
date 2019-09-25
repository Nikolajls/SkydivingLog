using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Gears
{
    [Table("[Gear].[Manufacturers]")]
    public class Manufacturer
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
