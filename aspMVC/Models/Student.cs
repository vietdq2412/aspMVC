using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace aspMVC.Models
{
    public class Student 
    {
        [Key] 
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public List<Subject>? Subjects { get; } = [];

        public int? ClassesId { get; set; } 
        public Classes? Classes { get; set; } = null!;
    }
}
