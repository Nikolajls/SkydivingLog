using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DropZones
{
    [Table("[DropZone].[DropZones]")]
    public class DropZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
}
