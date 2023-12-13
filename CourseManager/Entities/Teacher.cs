using System.ComponentModel.DataAnnotations;

namespace CourseManager.Entities
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public Guid teacherId { get; set; }
    }
}
