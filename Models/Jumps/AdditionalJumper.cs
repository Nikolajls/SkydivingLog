using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Jumps
{
    [Table("[Jump].[AdditionalJumpers]")]
    public class AdditionalJumper
    {
        public int JumpId { get; set; }
        public int PersonId { get; set; }
    }
}
