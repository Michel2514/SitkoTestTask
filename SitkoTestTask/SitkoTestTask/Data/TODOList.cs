namespace SitkoTestTask.Data
{
    public class TODOList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public bool Completed { get; set; }
    }
}
