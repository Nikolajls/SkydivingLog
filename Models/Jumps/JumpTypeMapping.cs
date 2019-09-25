using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Jumps
{
    [Table("[Jump].[JumpTypeMappings]")]
    public class JumpTypeMapping
    {
        public int JumpId { get; set; }
        public int JumpTypeId { get; set; }
    }
}
