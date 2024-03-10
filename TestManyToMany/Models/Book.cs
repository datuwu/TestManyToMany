using System.ComponentModel.DataAnnotations.Schema;

namespace TestManyToMany.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("BookId")]
        public virtual ICollection<PersonBook>? PersonBooks { get; set; }
    }
}
