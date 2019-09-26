using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Jumps
{
    [Table("[Jump].[Jumps]")]
    public class Jump
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CanopyId { get; set; }
        public int ContainerId { get; set; }
        public int Number { get; set; }
        public int Altitude { get; set; }
        public int SignedById { get; set; }
    }
}
