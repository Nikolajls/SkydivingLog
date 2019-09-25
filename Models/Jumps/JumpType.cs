using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Jumps
{
    [Table("[Jump].[JumpTypes]")]
    public class JumpType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
