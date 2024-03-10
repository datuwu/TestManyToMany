using System.ComponentModel.DataAnnotations.Schema;

namespace TestManyToMany.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("PersonId")]
        public virtual ICollection<PersonBook>? PersonBooks { get; set; }
    }
}
