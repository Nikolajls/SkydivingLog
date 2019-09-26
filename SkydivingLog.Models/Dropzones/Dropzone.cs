using System.ComponentModel.DataAnnotations.Schema;

namespace SkydivingLog.Models.Dropzones
{
    [Table("[Dropzone].[Dropzones]")]
    public class Dropzone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
}
