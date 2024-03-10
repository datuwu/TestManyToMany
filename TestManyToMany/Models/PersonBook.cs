namespace TestManyToMany.Models
{
    public class PersonBook
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Book? Book { get; set; }
    }
}
