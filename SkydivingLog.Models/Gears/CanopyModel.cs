using System.ComponentModel.DataAnnotations.Schema;

namespace SkydivingLog.Models.Gears
{
    [Table("[Gear].[CanopyModels]")]
    public class CanopyModel
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public int Cells { get; set; }
        public bool Elliptical { get; set; }
        public CanopyType Type { get; set; }
        public CanopyLevel Level { get; set; }

    }

    public enum CanopyLevel
    {
        Student,
        Novice,
        Experienced,
        VeryExperienced,
        ExtremelyExperienced
    }

    public enum CanopyType
    {
        Main,
        Reserve,
        Foil
    }
}
