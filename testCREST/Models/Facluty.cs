namespace testCREST.Models
{
    public class Facluty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public  ICollection<Student>? Students { get; set; }
    }
}
