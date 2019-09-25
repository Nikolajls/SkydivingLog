using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Persons
{
    [Table("[Person].[Persons]")]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
