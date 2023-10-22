using System.ComponentModel.DataAnnotations;

namespace testCREST.Models
{
    public class Student
    {
        
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        public bool Graduated { get; set; }
        public decimal Gpa { get; set; }
        public string? img { get; set; }
        public virtual int FaclutyId { get; set; }
        

        public virtual  Facluty? Facluty { get; set; }


    }
}
