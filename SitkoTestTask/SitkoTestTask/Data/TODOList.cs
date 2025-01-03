using System.ComponentModel.DataAnnotations;

namespace SitkoTestTask.Data
{
    public class TODOList
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateOnly CreationDate { get; set; }
        public DateOnly? ExecutionDate { get; set; }
        public bool Completed { get; set; } = false;
    }
}
